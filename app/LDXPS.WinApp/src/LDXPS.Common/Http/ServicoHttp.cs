using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using LDXPS.Common.Dto;
using Newtonsoft.Json;

namespace LDXPS.Common.Http
{
    public abstract class ServicoHttp
    {
        public static string BaseUrl { get; set; }
        public static int TimeOut { get; set; }
        public virtual Encoding Encoding { get; set; } = Encoding.UTF8;

        protected virtual List<KeyValuePair<string, string>> RequiredHeader { get; }
        public virtual List<HttpParametro> Header { get; set; }
        public virtual string MediaType { get; set; } = "application/json";
        public virtual IWebProxy Proxy { get; set; }

        protected virtual HttpClientHandler CriarHandler()
        {
            return new HttpClientHandler
            {
                UseDefaultCredentials = true,
                Proxy = ObterProxy()
            };
        }
        protected virtual RespostaHttp<T> CriarMensagemDeErro<T>(Exception ex)
        {
            return new RespostaHttp<T>
            {
                HouveErro = true,
                Erros = new List<string> { ex.ToString() }
            };
        }

        protected virtual string CaminhoUrlCompleto(string url)
        {
            return string.IsNullOrEmpty(BaseUrl)
                ? url
                : string.Concat(BaseUrl, url);
        }
        public async Task<RespostaHttp<TRetorno>> GetAsync<TRetorno>(string url, int timeOutEmSegundos = 20)
            where TRetorno : class, new()
        {
            try
            {
                using (var http = new HttpClient(CriarHandler()))
                {
                    http.Timeout = TimeSpan.FromSeconds(timeOutEmSegundos);
                    http.DefaultRequestHeaders.Add("Cache-Control", "no-cache");

                    var get = await http.GetAsync(CaminhoUrlCompleto(url));

                    var resposta = await get.Content.ReadAsStringAsync();


                    return new RespostaHttp<TRetorno>
                    {
                        Dados = JsonConvert.DeserializeObject<TRetorno>(resposta)
                    };
                }
            }
            catch (Exception e)
            {
                return CriarMensagemDeErro<TRetorno>(e);
            }
        }

        protected virtual IWebProxy ObterProxy()
        {
            var proxy = Proxy ?? WebRequest.DefaultWebProxy;
            return proxy ?? WebRequest.GetSystemWebProxy();
        }
        public RespostaHttp<TRetorno> Post<TObjeto, TRetorno>(string url, TObjeto objeto)
            where TRetorno : EntidadeBase, new()
        {
            return PostAsync<TObjeto, TRetorno>(url, objeto).Result;
        }
        public async Task<RespostaHttp<TRetorno>> PostAsync<TObjeto, TRetorno>(string url, TObjeto objeto)
            where TRetorno : class, new()
        {
            try
            {
                using (var http = new HttpClient(CriarHandler()))
                {
                    http.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
                    var json = JsonConvert.SerializeObject(objeto);

                    using (var stringContent = new StringContent(json, Encoding, MediaType))
                    {
                        var post = await http.PostAsync(CaminhoUrlCompleto(url), stringContent);

                        var resposta = await post.Content.ReadAsStringAsync();

                        return new RespostaHttp<TRetorno>
                        {
                            Dados = JsonConvert.DeserializeObject<TRetorno>(resposta)
                        };
                    }
                }
            }
            catch (Exception e)
            {
                return CriarMensagemDeErro<TRetorno>(e);
            }
        }

        public async Task<RespostaHttp<bool>> DeleteAsync(string url)
        {
            try
            {
                using (var http = new HttpClient(CriarHandler()))
                {
                    http.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
                    var post = await http.DeleteAsync(CaminhoUrlCompleto(url));

                    return new RespostaHttp<bool>
                    {
                        Dados = post.StatusCode == HttpStatusCode.NoContent
                    };
                }
            }
            catch (Exception e)
            {
                return CriarMensagemDeErro<bool>(e);
            }
        }
        public async Task<RespostaHttp<TRetorno>> PutAsync<TObjeto, TRetorno>(string url, TObjeto objeto)
            where TRetorno : class, new()
        {
            try
            {
                using (var http = new HttpClient(CriarHandler()))
                {
                    http.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
                    var json = JsonConvert.SerializeObject(objeto);

                    using (var stringContent = new StringContent(json, Encoding, MediaType))
                    {
                        var put = await http.PutAsync(CaminhoUrlCompleto(url), stringContent);
                        var resposta = await put.Content.ReadAsStringAsync();
                        return put.StatusCode == HttpStatusCode.NoContent ? new RespostaHttp<TRetorno>
                            {
                                Dados = JsonConvert.DeserializeObject<TRetorno>(resposta)
                            }
                            : new RespostaHttp<TRetorno>
                            {
                                HouveErro = true,
                                Erros = new List<string> { resposta }
                            };
                    }
                }
            }
            catch (Exception e)
            {
                return CriarMensagemDeErro<TRetorno>(e);
            }
        }
    }
}
