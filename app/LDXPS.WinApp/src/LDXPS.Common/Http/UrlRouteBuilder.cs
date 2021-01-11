
using System;

namespace LDXPS.Common.Http
{
    public class UrlRouteBuilder
    {
        private string _urlBuilder;

        public UrlRouteBuilder()
        {
            _urlBuilder = "";
        }


        public UrlRouteBuilder ParamDate(DateTime param)
        {
            ConcatenarValor(param.ToString("yyyy-MM-dd"));
            return this;
        }

        public UrlRouteBuilder ParamString(string param)
        {
            ConcatenarValor(param);
            return this;
        }

        public UrlRouteBuilder ParamEnum(int[] param)
        {
            var valores = string.Join("|", param);

            ConcatenarValor(valores);
            return this;
        }

        public UrlRouteBuilder ParamInt(int param)
        {
            ConcatenarValor(param.ToString());
            return this;
        }

        public string Build()
        {
            return _urlBuilder;
        }

        private void ConcatenarValor(string valor)
        {
            _urlBuilder += (string.IsNullOrEmpty(_urlBuilder) ? string.Empty : "/") + valor;
        }

    }
}
