using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BiografiaAspNet.Models
{
    public class DadosPessoais
    {
        public int DadosPessoaisID { get; set; }
        [Required]
        public string Nome { get; set; }

        [DisplayName("Data de Nascimento")]
        public string DataNascimento { get; set; }
        public string Naturalidade { get; set; }
        public string Nacionalidade { get; set; }
        public ICollection<ExpProfissional> ExpProfissionais { get; set; }
    }
}
