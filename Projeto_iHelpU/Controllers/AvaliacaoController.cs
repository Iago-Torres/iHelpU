﻿using iHelpU.MODEL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Projeto_iHelpU.Controllers
{ // Avaliação não está implementada ainda, provável que precise de alterações maiores
    // Importante não apagar essas criações de Index, Create, Details, deixa assim por enquanto, quando der alteração, aviso -> 09-12-2024
    public class AvaliacaoController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var db = new Banco_TCCContext();
            var listaAvaliacao = await db.Avaliacaos.ToListAsync();
            return View(listaAvaliacao);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Avaliacao avaliacao)
        {
            var db = new Banco_TCCContext();
            if (ModelState.IsValid)
            {
                db.Entry(avaliacao).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                await db.SaveChangesAsync();
                ViewData["Mensagem"] = "Dados salvos com sucesso.";
            }
            else
            {
                ViewData["MensagemErro"] = "Ocorreu um erro ao salvar os dados.";
            }
            return View(avaliacao);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var db = new Banco_TCCContext();
            var avaliacao = await db.TipoServicos.FindAsync(id);
            return View(avaliacao);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Avaliacao avaliacao)
        {
            var db = new Banco_TCCContext();
            if (ModelState.IsValid)
            {
                db.Entry(avaliacao).State = EntityState.Modified;
                await db.SaveChangesAsync();
                ViewData["Mensagem"] = "Dados alterados com sucesso.";
            }
            else
            {
                ViewData["MensagemErro"] = "Ocorreu um erro ao alterar os dados.";
            }
            return View(avaliacao);
        }
        public async Task<IActionResult> Details(int id)
        {
            var db = new Banco_TCCContext();
            var avaliacao = await db.TipoServicos.FirstOrDefaultAsync(x => x.Id == id);
            return View(avaliacao);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var db = new Banco_TCCContext();
            var avaliacao = await db.TipoServicos.FirstOrDefaultAsync(x => x.Id == id);
            return View(avaliacao);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Avaliacao avaliacao)
        {
            var db = new Banco_TCCContext();
            if (ModelState.IsValid)
            {
                db.Entry(avaliacao).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                ViewData["Mensagem"] = "Dados alterados com sucesso.";
            }
            else
            {
                ViewData["MensagemErro"] = "Ocorreu um erro ao alterar os dados.";
            }
            return View(avaliacao);
        }
    }
}
