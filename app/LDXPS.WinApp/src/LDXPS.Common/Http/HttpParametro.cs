
namespace LDXPS.Common.Http
{
    public class HttpParametro
    {
        public HttpParametro(string nome, object valor)
        {
            Nome = nome;
            Valor = valor;
        }

        public string Nome { get; private set; }
        public object Valor { get; private set; }
    }
}
