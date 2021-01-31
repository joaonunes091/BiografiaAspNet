using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BiografiaAspNet.Models
{
    public class ExpProfissional
    {
        public int ExpProfissionalID { get; set; }
        public int DadosPessoaisID { get; set; }
        public DadosPessoais DadosPessoais { get; set; }
        public string Entidade { get; set; }

        [DisplayName("Período de Exercicio de Funções")]
        public string Periodo { get; set; }

        [DisplayName("Funções")]
        public string Funcoes { get; set; }
    }
}
