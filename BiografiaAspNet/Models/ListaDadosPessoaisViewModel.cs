using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiografiaAspNet.Models
{
    public class ListaDadosPessoaisViewModel
    {
        public List<DadosPessoais> DadosPessoais { get; set; }
        public Paginacao Paginacao { get; set; }
    }
}
