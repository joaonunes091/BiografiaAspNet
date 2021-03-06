﻿using BiografiaAspNet.Data;
using BiografiaAspNet.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
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

        [Authorize]
        //public IActionResult Index()
        //{
        //    IEnumerable<DadosPessoais> dadosPessoais = _db.DadosPessoais;
        //    return View(dadosPessoais);
        //}
        public async Task<IActionResult> Index(string nomePesquisar, int pagina = 1)
        {
            Paginacao paginacao = new Paginacao
            {
                TotalItems = await _db.DadosPessoais.Where(p => nomePesquisar == null || p.Nome.Contains(nomePesquisar)).CountAsync(),
                PaginaAtual = pagina
            };

            List<DadosPessoais> dadosPessoais = await _db.DadosPessoais.Where(p => nomePesquisar == null || p.Nome.Contains(nomePesquisar))
                .OrderBy(p => p.Nome)
                .Skip(paginacao.ItemsPorPagina * (pagina - 1))
                .Take(paginacao.ItemsPorPagina)
                .ToListAsync();

            ListaDadosPessoaisViewModel modelo = new ListaDadosPessoaisViewModel
            {
                Paginacao = paginacao,
                DadosPessoais = dadosPessoais,
                NomePesquisar = nomePesquisar
            };

            return base.View(modelo);
        }
        //All
        public async Task<IActionResult> IndexAll(string nomePesquisar, int pagina = 1)
        {
            Paginacao paginacao = new Paginacao
            {
                TotalItems = await _db.DadosPessoais.Where(p => nomePesquisar == null || p.Nome.Contains(nomePesquisar)).CountAsync(),
                PaginaAtual = pagina
            };

            List<DadosPessoais> dadosPessoais = await _db.DadosPessoais.Where(p => nomePesquisar == null || p.Nome.Contains(nomePesquisar))
                .OrderBy(p => p.Nome)
                .Skip(paginacao.ItemsPorPagina * (pagina - 1))
                .Take(paginacao.ItemsPorPagina)
                .ToListAsync();

            ListaDadosPessoaisViewModel modelo = new ListaDadosPessoaisViewModel
            {
                Paginacao = paginacao,
                DadosPessoais = dadosPessoais,
                NomePesquisar = nomePesquisar
            };

            return base.View(modelo);
        }
        // GET: ExpProfissional/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dadosPessoais = await _db.DadosPessoais
                .Include(e => e.ExpProfissionais)
                .FirstOrDefaultAsync(m => m.DadosPessoaisID == id);
            if (dadosPessoais == null)
            {
                return NotFound();
            }

            return View(dadosPessoais);
        }

        public async Task<IActionResult> DetailsAll(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dadosPessoais = await _db.DadosPessoais
                .Include(e => e.ExpProfissionais)
                .FirstOrDefaultAsync(m => m.DadosPessoaisID == id);
            if (dadosPessoais == null)
            {
                return NotFound();
            }

            return View(dadosPessoais);
        }
        //GET - Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        //POST - Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("DadosPessoaisID,Nome,DataNascimento,Naturalidade,Nacionalidade")] DadosPessoais dadosPessoais, IFormFile ficheiroFoto)
        {
            if (ModelState.IsValid)
            {
                if(ficheiroFoto != null && ficheiroFoto.Length > 0)
                {
                    using (var ficheiroMemoria = new MemoryStream())
                    {
                        ficheiroFoto.CopyTo(ficheiroMemoria);
                        dadosPessoais.Foto = ficheiroMemoria.ToArray();
                    }
                }

                _db.DadosPessoais.Add(dadosPessoais);
                await _db.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            }
            ViewBag.Mensagem = "Currículo adicionado com sucesso.";
            return View("Sucesso");
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

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DadosPessoaisID,Nome,DataNascimento,Naturalidade,Nacionalidade")] DadosPessoais dadosPessoais, IFormFile ficheiroFoto)
        {
            if (id != dadosPessoais.DadosPessoaisID)
            {
                return NotFound();
            }
            try
            {
                if (ficheiroFoto != null && ficheiroFoto.Length > 0)
                {
                    using (var ficheiroMemoria = new MemoryStream())
                    {
                        ficheiroFoto.CopyTo(ficheiroMemoria);
                        dadosPessoais.Foto = ficheiroMemoria.ToArray();
                    }
                }
                _db.Update(dadosPessoais);
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                ModelState.AddModelError("", "Ocorreu um erro. Não foi possível guardar o currículo. Tente novamente e se o problema persistir contacte a assistência.");
                return View(dadosPessoais);

            }

            ViewBag.Mensagem = "Currículo alterado com sucesso";
            return View("Sucesso");
        }


        // GET: Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dadosPessoais = await _db.DadosPessoais
                .SingleOrDefaultAsync(p => p.DadosPessoaisID == id);

            if (dadosPessoais == null)
            {
                ViewBag.Mensagem = "O currículo que estava a tentar apagar foi eliminado por outra pessoa.";
                return View("Sucesso");
            }

            return View(dadosPessoais);
        }

        // POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dadosPessoais = await _db.DadosPessoais.FindAsync(id);
            _db.DadosPessoais.Remove(dadosPessoais);
            await _db.SaveChangesAsync();

            ViewBag.Mensagem = "O currículo foi eliminado com sucesso";
            return View("Sucesso");
        }

        private bool DadosPessoaisExists(int id)
        {
            return _db.DadosPessoais.Any(p => p.DadosPessoaisID == id);
        }


    }
}
