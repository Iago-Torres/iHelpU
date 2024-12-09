using iHelpU.MODEL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Projeto_iHelpU.Controllers
    // Precisa de muitas alterações, temos de ver sobre como implementar as competências de um modo que se interligue com os tipos de serviço
{
    public class CompetenciaController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var db = new BancoTccContext();
            var listaCompetencia = await db.Competencias.ToListAsync();
            return View(listaCompetencia);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Competencia competencia)
        {
            var db = new BancoTccContext();
            if (ModelState.IsValid)
            {
                db.Entry(competencia).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                await db.SaveChangesAsync();
                ViewData["Mensagem"] = "Dados salvos com sucesso.";
            }
            else
            {
                ViewData["MensagemErro"] = "Ocorreu um erro ao salvar os dados.";
            }
            return View(competencia);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var db = new BancoTccContext();
            var competencia = await db.TipoServicos.FindAsync(id);
            return View(competencia);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Competencia competencia)
        {
            var db = new BancoTccContext();
            if (ModelState.IsValid)
            {
                db.Entry(competencia).State = EntityState.Modified;
                await db.SaveChangesAsync();
                ViewData["Mensagem"] = "Dados alterados com sucesso.";
            }
            else
            {
                ViewData["MensagemErro"] = "Ocorreu um erro ao alterar os dados.";
            }
            return View(competencia);
        }
        public async Task<IActionResult> Details(int id)
        {
            var db = new BancoTccContext();
            var competencia = await db.TipoServicos.FirstOrDefaultAsync(x => x.Id == id);
            return View(competencia);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var db = new BancoTccContext();
            var competencia = await db.TipoServicos.FirstOrDefaultAsync(x => x.Id == id);
            return View(competencia);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Competencia competencia)
        {
            var db = new BancoTccContext();
            if (ModelState.IsValid)
            {
                db.Entry(competencia).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                ViewData["Mensagem"] = "Dados alterados com sucesso.";
            }
            else
            {
                ViewData["MensagemErro"] = "Ocorreu um erro ao alterar os dados.";
            }
            return View(competencia);
        }

    }
}
