using iHelpU.MODEL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Projeto_iHelpU.Controllers
{
    public class AnuncioController : Controller
    {
        private readonly BancoTccContext _context;
        public AnuncioController(BancoTccContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var anuncios = await _context.AnuncioServicos
                .Include(a => a.TipoServico)
                .Include(a => a.Usuario)
                .Include(a => a.IdStatusNavigation)
                .ToListAsync();

            return View(anuncios);
        }


        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AnuncioServico anuncio)
        {
            var db = new BancoTccContext();
            if (ModelState.IsValid)
            {
                db.Entry(anuncio).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                await db.SaveChangesAsync();
                ViewData["Mensagem"] = "Dados salvos com sucesso.";
            }
            else
            {
                ViewData["MensagemErro"] = "Ocorreu um erro ao salvar os dados.";
            }
            return View(anuncio);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var db = new BancoTccContext();
            var anuncio = await db.TipoServicos.FindAsync(id);
            return View(anuncio);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(AnuncioServico competencia)
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
            var anuncio = _context.AnuncioServicos
            .Include(a => a.Usuario)
            .Include(a => a.TipoServico)
           .Include(a => a.IdStatusNavigation)
           .FirstOrDefault(a => a.Id == id);

            if (anuncio == null)
            {
                return NotFound();
            }

            return View(anuncio);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var db = new BancoTccContext();
            var anuncio = await db.TipoServicos.FirstOrDefaultAsync(x => x.Id == id);
            return View(anuncio);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(AnuncioServico anuncio)
        {
            var db = new BancoTccContext();
            if (ModelState.IsValid)
            {
                db.Entry(anuncio).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                ViewData["Mensagem"] = "Dados alterados com sucesso.";
            }
            else
            {
                ViewData["MensagemErro"] = "Ocorreu um erro ao alterar os dados.";
            }
            return View(anuncio);
        }

    }
}