using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiografiaAspNet.Models
{
    public class ExperienciaProfissional
    {
        public int Id { get; set; }
        public string Entidade { get; set; }
        public string Periodo { get; set; }
        public string Funcoes { get; set; }
    }
}
