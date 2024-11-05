using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using iHelpU.MODEL.Models;
using iHelpU.MODEL.Interface_Services;
using iHelpU.MODEL.ViewModel;

namespace Projeto_iHelpU.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUsuario_Service _usuarioService;

        public AuthController(IUsuario_Service usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // Exibe a página de login
        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("HomePage", "iHelpU");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                // Busca o usuário pelo email e senha
                var usuario = await _usuarioService.ObterUsuarioporCredencial(model.Email, model.Senha);

                if (usuario != null)
                {
                    // Define as claims com o nome e ID do usuário
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, usuario.PrimeiroNome),
                        new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString())
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    // Redireciona para a página inicial após login
                    return RedirectToAction("HomePage", "iHelpU");
                }

                ModelState.AddModelError("", "Credenciais inválidas.");
            }
            return View(model);
        }

        // Logout do usuário
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Auth");
        }
    }
}
