using Microsoft.AspNetCore.Mvc;
using iHelpU.MODEL.Interface_Services;
using iHelpU.MODEL.Models;
using iHelpU.MODEL.ViewModel;
using System.Threading.Tasks;
using iHelpU.MODEL.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;

namespace Projeto_iHelpU.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsuario_Service _usuarioService;

        public AccountController(IUsuario_Service usuarioService)
        {
            _usuarioService = usuarioService;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

       [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var usuario = await _usuarioService.ObterUsuarioporCredencial(model.Email, model.Senha);

                if (usuario != null)
                {
                    
                    HttpContext.Session.SetString("UsuarioId", usuario.Id.ToString());
                    return RedirectToAction("HomePage", "iHelpU");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Credenciais inválidas.");
                }
            }

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {       // Realizar logout 
                HttpContext.Session.Clear();
                return RedirectToAction("Login", "Auth");
        
        }
    }
}
