using iHelpU.MODEL.Interface_Services; // Use a interface
using iHelpU.MODEL.Models;
using iHelpU.MODEL.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Projeto_iHelpU.Controllers
{
    public class iHelpUController : Controller
    {
        private readonly IAnuncioServico_Service _serviceAnuncio;

        // Use a interface em vez da implementação
        public iHelpUController(IAnuncioServico_Service serviceAnuncio)
        {
            _serviceAnuncio = serviceAnuncio;
        }

        public async Task<IActionResult> HomePage()
        {
            var anuncios = await _serviceAnuncio.GetAllAsync();
            var viewModel = new HomePageVM
            {
                MensagemBemVindo = "Bem-vindo ao iHelpU!",
                Anuncios = anuncios // Use diretamente a lista de anúncios
            };
            return View(viewModel);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}