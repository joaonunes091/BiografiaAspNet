using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BiografiaAspNet.Data;
using BiografiaAspNet.Models;

namespace BiografiaAspNet.Controllers
{
    public class ExpProfissionalController : Controller
    {
        private readonly BiografiaAspNetDbContext _db;

        public ExpProfissionalController(BiografiaAspNetDbContext context)
        {
            _db = context;
        }

        // GET: ExpProfissional
        public async Task<IActionResult> Index()
        {
            var biografiaAspNetDbContext = _db.ExperienciaProfissional.Include(e => e.DadosPessoais);
            return View(await biografiaAspNetDbContext.ToListAsync());
        }

        // GET: ExpProfissional/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expProfissional = await _db.ExperienciaProfissional
                .Include(e => e.DadosPessoais)
                .FirstOrDefaultAsync(m => m.ExpProfissionalID == id);
            if (expProfissional == null)
            {
                return NotFound();
            }

            return View(expProfissional);
        }

        // GET: ExpProfissional/Create
        public IActionResult Create()
        {
            ViewData["DadosPessoaisID"] = new SelectList(_db.DadosPessoais, "DadosPessoaisID", "Nome");
            return View();
        }

        // POST: ExpProfissional/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExpProfissionalID,DadosPessoaisID,Entidade,Periodo,Funcoes")] ExpProfissional expProfissional)
        {
            if (ModelState.IsValid)
            {
                _db.Add(expProfissional);
                await _db.SaveChangesAsync();
                ViewBag.Mensagem = "Experiência profissional adicionada com sucesso";
                return View("Sucesso");
            }
            //ViewData["DadosPessoaisID"] = new SelectList(_db.DadosPessoais, "DadosPessoaisID", "Nome", expProfissional.DadosPessoaisID);
            return View ();
        }

        // GET: ExpProfissional/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expProfissional = await _db.ExperienciaProfissional.FindAsync(id);
            if (expProfissional == null)
            {
                return View("Inexistente");
            }
            ViewData["DadosPessoaisID"] = new SelectList(_db.DadosPessoais, "DadosPessoaisID", "Nome", expProfissional.DadosPessoaisID);
            return View(expProfissional);
        }

        // POST: ExpProfissional/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExpProfissionalID,DadosPessoaisID,Entidade,Periodo,Funcoes")] ExpProfissional expProfissional)
        {
            if (id != expProfissional.ExpProfissionalID)
            {
                return NotFound();
            }
            try
            {
                _db.Update(expProfissional);
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                ModelState.AddModelError("", "Ocorreu um erro. Não foi possível guardar o currículo. Tente novamente e se o problema persistir contacte a assistência.");
                return View("Erro");

            }

            ViewBag.Mensagem = "Currículo alterado com sucesso";
            return View("Sucesso");
        }

        // GET: ExpProfissional/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expProfissional = await _db.ExperienciaProfissional
                .Include(e => e.DadosPessoais)
                .FirstOrDefaultAsync(m => m.ExpProfissionalID == id);
            if (expProfissional == null)
            {
                return NotFound();
            }

            return View(expProfissional);
        }

        // POST: ExpProfissional/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expProfissional = await _db.ExperienciaProfissional.FindAsync(id);
            _db.ExperienciaProfissional.Remove(expProfissional);
            await _db.SaveChangesAsync();
            ViewBag.Mensagem = "Experiência profissional eliminada com sucesso";
            return View("Sucesso");
        }

        private bool ExpProfissionalExists(int id)
        {
            return _db.ExperienciaProfissional.Any(e => e.ExpProfissionalID == id);
        }
    }
}
