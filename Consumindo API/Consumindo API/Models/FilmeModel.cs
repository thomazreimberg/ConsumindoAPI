using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumindo_API.Models
{
    class FilmeModel
    {
        public int IdFilme { get; set; }
        public string NmFilme { get; set; }
        public string DsCategoria { get; set; }
        public DateTime DtLancamento { get; set; }
    }
}
