using BiografiaAspNet.Data;
using BiografiaAspNet.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiografiaAspNet.Controllers
{
    public class DadosPessoaisController : Controller
    {
        private readonly BiografiaAspNetDbContext db;

        public DadosPessoaisController(BiografiaAspNetDbContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            IEnumerable <DadosPessoais> dadosPessoais = db.DadosPessoais;
            return View(dadosPessoais);
        }
    }
}
