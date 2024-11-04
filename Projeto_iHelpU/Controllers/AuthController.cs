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

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var usuario = await _usuarioService.ObterUsuarioporCredencial(model.Email, model.Senha);

                if (usuario != null)
                {
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuario.PrimeiroNome),
                    new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString())
                };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    return RedirectToAction("HomePage", "iHelpU");
                }

                ModelState.AddModelError("", "Credenciais inválidas.");
            }
            return View(model); // redireciona para a página de login se falhar
        }
    }
}