using iHelpU.MODEL.Interface_Services; // Use a interface
using iHelpU.MODEL.Models;
using iHelpU.MODEL.Services;
using iHelpU.MODEL.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Projeto_iHelpU.Controllers
{
    public class iHelpUController : Controller
    {
        private readonly IAnuncioServico_Service _serviceAnuncio;
        private readonly BancoTccContext _context;
        private readonly ITipoServico_Service _serviceTipoServico;
        public iHelpUController(IAnuncioServico_Service serviceAnuncio, ITipoServico_Service serviceTipoServico)
        {
            _serviceAnuncio = serviceAnuncio;
            _serviceTipoServico = serviceTipoServico;
        }

        public async Task<IEnumerable<TipoServico>> GetTiposServicos()
        {
            return await _context.TipoServicos.ToListAsync();
        }

        public async Task<IActionResult> HomePage(int? tipoServicoId)
        {
            var anuncios = await _serviceAnuncio.GetAllAsync();
            var tiposServico = await _serviceTipoServico.GetAllAsync();

            if (tipoServicoId.HasValue)
            {
                anuncios = anuncios.Where(a => a.TipoServicoId == tipoServicoId).ToList();
            }

            var viewModel = new HomePageVM
            {
                MensagemBemVindo = "Bem-vindo ao iHelpU!",
                Anuncios = anuncios,
                TiposServico = tiposServico,
                TipoServicoSelecionado = tipoServicoId // Passa o valor selecionado
            };

            return View(viewModel);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}