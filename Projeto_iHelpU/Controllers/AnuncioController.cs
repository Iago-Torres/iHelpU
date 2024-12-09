using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using iHelpU.MODEL.Models;
using iHelpU.MODEL.ViewModel;
using iHelpU.MODEL.Repositories;
using iHelpU.MODEL.Helpers;
using iHelpU.MODEL.Services;

namespace Projeto_iHelpU.Controllers
{
    public class AnuncioController : Controller
    {
        private readonly BancoTccContext _context;
        private readonly AnuncioServico_Service _serviceAnuncio;
        public AnuncioController(BancoTccContext context)
        {
            _context = context;
            _serviceAnuncio = new AnuncioServico_Service(context);
        }

        public async Task<AnuncioServico> SelecionarChaveAsync(int id)
        {
            return await _context.AnuncioServicos.FindAsync(id);
        }
        private IEnumerable<SelectListItem> ObterListaTiposServico()
        {
            var tiposServico = _context.TipoServicos.ToList();
            return tiposServico.Select(tipo => new SelectListItem
            {
                Value = tipo.Id.ToString(),
                Text = tipo.Descricao
            });
        }
        private IEnumerable<SelectListItem> ObterListaStatus()
        {
            var statuses = _context.Statuses.ToList();
            return statuses.Select(status => new SelectListItem
            {
                Value = status.Id.ToString(),
                Text = status.Descricao
            });
        }
        private int? ObterUsuarioLogado() // -> Obter o Usuário Logado só funciona dentro do mesmo re´positório, não funciona chamando de outro lugar
        {
            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (int.TryParse(userIdString, out int userId))
            {
                return userId;
            }
            return null;
        }
        // -> Métodos que retornam Lista tanto de Status e Tipos de Serviço
        private void CarregarTiposServico()
        {
            var tiposServico = TipoServicoHelper.ObterTiposServico(_context);
            ViewBag.TiposServico = tiposServico.Select(tipo => new SelectListItem
            {
                Value = tipo.Id.ToString(),
                Text = tipo.Descricao
            });
        }
        private void CarregarStatus()
        {
            var statuses = Status_Helper.ObterTodosStatus(_context);
            ViewBag.Status = statuses.Select(status => new SelectListItem
            {
                Value = status.Id.ToString(),
                Text = status.Descricao
            });
        }
        // -> Carregamento dos métodos acima
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
            CarregarTiposServico();
            CarregarStatus();
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Create(AnuncioServico anuncio)
        {
            var usuarioId = ObterUsuarioLogado();
            ModelState.Remove("Id");
            if (ModelState.IsValid)
            {
                if (usuarioId.HasValue)
                {
                    anuncio.UsuarioId = usuarioId.Value;
                }
                _context.Entry(anuncio).State = EntityState.Added;
                await _context.SaveChangesAsync();
                ViewData["Mensagem"] = "Dados salvos com sucesso.";
            }
            else
            {
                ViewData["MensagemErro"] = "Ocorreu um erro ao salvar os dados.";
            }
            CarregarTiposServico();
            CarregarStatus();
            
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

        public async Task<IActionResult> ServicosPrestados()
        {
            var userId = ObterUsuarioLogado(); 
            if (userId == null) return Unauthorized();

            var servicosPrestados = await _context.ContratacaoServicos
                .Include(c => c.AnuncioServico)
                    .ThenInclude(a => a.TipoServico)
                .Include(c => c.AnuncioServico.IdStatusNavigation)
                .Where(c => c.AnuncioServico.UsuarioId == userId)
                .ToListAsync();

            return View(servicosPrestados);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var usuario = await _serviceAnuncio.oRepositoryAnuncioServico.SelecionarChaveAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            CarregarTiposServico();
            CarregarStatus();
            return View(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AnuncioServico anuncio)
        {
            var usuarioId = ObterUsuarioLogado();
            if (ModelState.IsValid)
            {
                if (usuarioId.HasValue)
                {
                    anuncio.UsuarioId = usuarioId.Value;
                }
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
                coordenada_x = anuncio.CoordenadaX,
                coordenada_y = anuncio.CoordenadaY,
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
