using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using iHelpU.MODEL.Models;
using iHelpU.MODEL.ViewModel;

namespace Projeto_iHelpU.Controllers
{
    public class AnuncioController : Controller
    {
        private readonly BancoTccContext _context;

        public AnuncioController(BancoTccContext context)
        {
            _context = context;
        }

        private int? ObterUsuarioLogado()
        {
            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (int.TryParse(userIdString, out int userId))
            {
                return userId;
            }
            return null;
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
        }   public IActionResult TesteMapa()
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

        public async Task<IActionResult> ServicosCriados()
        {
            var userId = ObterUsuarioLogado(); 
            if (userId == null) return Unauthorized();

            var servicosCriados = await _context.AnuncioServicos
                .Where(a => a.UsuarioId == userId)
                .Include(a => a.TipoServico)
                .Include(a => a.IdStatusNavigation)
                .ToListAsync();

            return View(servicosCriados);
        }

        // Exibe os serviços prestados pelo usuário logado
        public async Task<IActionResult> ServicosPrestados()
        {
            var userId = ObterUsuarioLogado(); // Usa o método para obter o ID do usuário logado
            if (userId == null) return Unauthorized();

            // Buscar os serviços contratados
            var servicosPrestados = await _context.ContratacaoServicos
                .Include(c => c.AnuncioServico)
                    .ThenInclude(a => a.TipoServico)
                .Include(c => c.AnuncioServico.IdStatusNavigation)
                .Where(c => c.AnuncioServico.UsuarioId == userId)
                .ToListAsync();

            return View(servicosPrestados);
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

            var viewModel = new AnuncioDetalhesVM
            {
                Id = anuncio.Id,
                coordenada_x = (decimal)anuncio.CoordenadaX,
                coordenada_y = (decimal)anuncio.CoordenadaY,
            };

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
