using BiografiaAspNet.Data;
using BiografiaAspNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
            IEnumerable<DadosPessoais> dadosPessoais = _db.DadosPessoais;
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
        public async Task<IActionResult> Create([Bind("Id,Nome,DataNascimento,Naturalidade,Nacionalidade")] DadosPessoais dadosPessoais)
        {
            _db.DadosPessoais.Add(dadosPessoais);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dadosPessoais = await _db.DadosPessoais.FindAsync(id);

            if (dadosPessoais == null)
            {
                return View("Inexistente");
            }

            return View(dadosPessoais);
        }

        // POST: Produtos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,DataNascimento,Naturalidade,Nacionalidade")] DadosPessoais dadosPessoais)
        {
            if (id != dadosPessoais.Id)
            {
                return NotFound();
            }
            try
            {
                _db.Update(dadosPessoais);
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                ModelState.AddModelError("", "Ocorreu um erro. Não foi possível guardar o produto. Tente novamente e se o problema persistir contacte a assistência.");
                return View(dadosPessoais);

            }

            ViewBag.Mensagem = "Produto alterado com sucesso";
            return View("Sucesso");
        }



    }
}
