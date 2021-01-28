using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BiografiaAspNet.Models
{
    public class DadosPessoais
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [DisplayName("Data de Nascimento")]
        public string DataNascimento { get; set; }
        public string Naturalidade { get; set; }
        public string Nacionalidade { get; set; }
    }
}
