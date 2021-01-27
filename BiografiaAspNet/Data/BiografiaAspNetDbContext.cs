using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BiografiaAspNet.Data
{
    public class BiografiaAspNetDbContext : DbContext
    {
        public BiografiaAspNetDbContext(DbContextOptions<BiografiaAspNetDbContext> options) : base(options)
        {

        }

        public DbSet<BiografiaAspNet.Models.DadosPessoais> DadosPessoais { get; set; }
        public DbSet<BiografiaAspNet.Models.ExperienciaProfissional> ExperienciaProfissional { get; set; }
        public DbSet<BiografiaAspNet.Models.Formacao> Formacao { get; set; }

    }
}
