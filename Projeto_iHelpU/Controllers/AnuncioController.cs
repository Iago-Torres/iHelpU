using iHelpU.MODEL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace Projeto_iHelpU.Controllers
{
    public class AnuncioController : Controller
    {
        private readonly BancoTccContext _context;

        public AnuncioController(BancoTccContext context)
        {
            _context = context;
        }

        // Exibe todos os anúncios na página principal
        public async Task<IActionResult> Index()
        {
            var anuncios = await _context.AnuncioServicos
                .Include(a => a.TipoServico)
                .Include(a => a.Usuario)
                .Include(a => a.IdStatusNavigation)
                .ToListAsync();

            return View(anuncios);
        }

        // Exibe os serviços criados pelo usuário logado
        public async Task<IActionResult> MeusServicosCriados()
        {
            var userId = User.FindFirst("sub")?.Value;
            if (userId == null) return Unauthorized();

            var servicosCriados = await _context.AnuncioServicos
                .Where(a => a.UsuarioId == int.Parse(userId))
                .Include(a => a.TipoServico)
                .Include(a => a.IdStatusNavigation)
                .ToListAsync();

            return View(servicosCriados);
        }

        // Exibe os serviços prestados pelo usuário logado
        public async Task<IActionResult> MeusServicosPrestados()
        {
            var userId = User.FindFirst("sub")?.Value;
            if (userId == null) return Unauthorized();

            var servicosPrestados = await _context.ContratacaoServicos
                .Include(c => c.AnuncioServico)
                    .ThenInclude(a => a.TipoServico)
                .Include(c => c.AnuncioServico.IdStatusNavigation)
                .Where(c => c.AnuncioServico.UsuarioId == int.Parse(userId))
                .Select(c => c.AnuncioServico)
                .ToListAsync();

            return View(servicosPrestados);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AnuncioServico anuncio)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(anuncio).State = EntityState.Added;
                await _context.SaveChangesAsync();
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
            var anuncio = await _context.AnuncioServicos.FindAsync(id);
            if (anuncio == null) return NotFound();

            return View(anuncio);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AnuncioServico anuncio)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(anuncio).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                ViewData["Mensagem"] = "Dados alterados com sucesso.";
            }
            else
            {
                ViewData["MensagemErro"] = "Ocorreu um erro ao alterar os dados.";
            }
            return View(anuncio);
        }

        public async Task<IActionResult> Details(int id)
        {
            var anuncio = await _context.AnuncioServicos
                .Include(a => a.Usuario)
                .Include(a => a.TipoServico)
                .Include(a => a.IdStatusNavigation)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (anuncio == null) return NotFound();

            return View(anuncio);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var anuncio = await _context.AnuncioServicos.FirstOrDefaultAsync(x => x.Id == id);
            if (anuncio == null) return NotFound();

            return View(anuncio);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(AnuncioServico anuncio)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(anuncio).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
                ViewData["Mensagem"] = "Anúncio excluído com sucesso.";
            }
            else
            {
                ViewData["MensagemErro"] = "Ocorreu um erro ao excluir o anúncio.";
            }
            return View(anuncio);
        }
    }
}
