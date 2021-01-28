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
        private readonly BiografiaAspNetDbContext _db;

        public DadosPessoaisController(BiografiaAspNetDbContext context)
        {
            _db = context;
        }

        public IActionResult Index()
        {
            IEnumerable <DadosPessoais> dadosPessoais = _db.DadosPessoais;
            return View(dadosPessoais);
        }

        //GET - Create
        public IActionResult Create()
        {
            return View();
        }

        //POST - Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,DataNascimento,Naturalidade,Nacionalidade")]DadosPessoais dadosPessoais)
        {
            _db.DadosPessoais.Add(dadosPessoais);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
