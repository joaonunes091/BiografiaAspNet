//using BiografiaAspNet.Data;
//using BiografiaAspNet.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace BiografiaAspNet.Controllers
//{
//    public class ExpProfissionalController : Controller
//    {
//        private readonly BiografiaAspNetDbContext _db;
//        public ExpProfissionalController(BiografiaAspNetDbContext context)
//        {
//            _db = context;
//        }

//        public IActionResult Index()
//        {
//            IEnumerable<ExpProfissional> expProfissionals = _db.ExperienciaProfissional;
//            return View(expProfissionals);
//        }

//        //GET - Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        //POST - Create
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("ExpProfissionalID,DadosPessoaisID,Entidade,Periodo,Funcoes")] ExpProfissional expProfissional)
//        {
//            _db.ExperienciaProfissional.Add(expProfissional);
//            await _db.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        // GET: Edit
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var expProfissional = await _db.ExperienciaProfissional.FindAsync(id);

//            if (expProfissional == null)
//            {
//                return View("Inexistente");
//            }

//            return View(expProfissional);
//        }

//        // POST: Edit
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("ExpProfissionalID,DadosPessoaisID,Entidade,Periodo,Funcoes")] ExpProfissional expProfissional)
//        {
//            if (id != expProfissional.ExpProfissionalID)
//            {
//                return NotFound();
//            }
//            try
//            {
//                _db.Update(expProfissional);
//                await _db.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {

//                ModelState.AddModelError("", "Ocorreu um erro. Não foi possível guardar a experoência. Tente novamente e se o problema persistir contacte a assistência.");
//                return View(expProfissional);

//            }

//            ViewBag.Mensagem = "Experiência alterada com sucesso";
//            return View("Sucesso");
//        }


//        // GET: Delete
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var expProfissional = await _db.ExperienciaProfissional
//                .SingleOrDefaultAsync(p => p.ExpProfissionalID == id);

//            if (expProfissional == null)
//            {
//                ViewBag.Mensagem = "Já não existe a experiência que prentendia eliminar.";
//                return View("Sucesso");
//            }

//            return View(expProfissional);
//        }

//        // POST: Delete
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var expProfissional = await _db.ExperienciaProfissional.FindAsync(id);
//            _db.ExperienciaProfissional.Remove(expProfissional);
//            await _db.SaveChangesAsync();

//            ViewBag.Mensagem = "A Experiência Profissional foi eliminada com sucesso";
//            return View("Sucesso");
//        }

//        private bool ExperienciaProfissionalExists(int id)
//        {
//            return _db.ExperienciaProfissional.Any(p => p.ExpProfissionalID == id);
//        }

//    }

//}
