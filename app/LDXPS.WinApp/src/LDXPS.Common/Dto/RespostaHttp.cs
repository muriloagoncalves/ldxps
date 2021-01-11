
using System.Collections.Generic;

namespace LDXPS.Common.Dto
{
    public class RespostaHttp<T>
    {
        public List<string> Erros { get; set; }
        public bool HouveErro { get; set; }
        public T Dados { get; set; }
    }
}
