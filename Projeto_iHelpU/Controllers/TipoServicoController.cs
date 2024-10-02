using iHelpU.MODEL.Models;
using iHelpU.MODEL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Projeto_iHelpU.Controllers
{
    public class TipoServicoController: Controller
    {

        private BancoTccContext _context;
        public RepositoryTipoServico _RepositoryTipoServico;
        public async Task<IActionResult> Index()
        {
            var db = new BancoTccContext();
            var listaTipoServico = await db.TipoServicos.ToListAsync();
            return View(listaTipoServico);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(TipoServico tipoServico)
        {
            var db = new BancoTccContext();
            if (ModelState.IsValid)
            {
                db.Entry(tipoServico).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                await db.SaveChangesAsync();
                ViewData["Mensagem"] = "Dados salvos com sucesso.";
            }
            else
            {
                ViewData["MensagemErro"] = "Ocorreu um erro ao salvar os dados.";
            }
            return View(tipoServico);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var db = new BancoTccContext();
            var unidade = await db.TipoServicos.FindAsync(id);
            return View(unidade);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(TipoServico tipoServico)
        {
            var db = new BancoTccContext();
            if (ModelState.IsValid)
            {
                db.Entry(tipoServico).State = EntityState.Modified;
                await db.SaveChangesAsync();
                ViewData["Mensagem"] = "Dados alterados com sucesso.";
            }
            else
            {
                ViewData["MensagemErro"] = "Ocorreu um erro ao alterar os dados.";
            }
            return View(tipoServico);
        }
        public async Task<IActionResult> Details(int id)
        {
            var db = new BancoTccContext();
            var tipoServico = await db.TipoServicos.FirstOrDefaultAsync(x => x.Id == id);
            return View(tipoServico);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var db = new BancoTccContext();
            var unidade = await db.TipoServicos.FirstOrDefaultAsync(x => x.Id == id);
            return View(unidade);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(TipoServico tipoServico)
        {
            var db = new BancoTccContext();
            if (ModelState.IsValid) 
            {
                db.Entry(tipoServico).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                ViewData["Mensagem"] = "Dados alterados com sucesso.";
            }
            else
            {
                ViewData["MensagemErro"] = "Ocorreu um erro ao alterar os dados.";
            }
            return View(tipoServico);
        }

    }
}


