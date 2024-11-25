using iHelpU.MODEL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using iHelpU.MODEL.Repositories;
using iHelpU.MODEL.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using iHelpU.MODEL.Interface_Services;

namespace Projeto_iHelpU.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioService _serviceUsuario;
        private readonly UsuarioController _context;

        public UsuarioController(BancoTccContext context)
        {
            _serviceUsuario = new UsuarioService(context); 
            
           
        }

      
        public async Task<IActionResult> Index()
        {
            var listaUsuario = await _serviceUsuario.oRepositoryUsuario.SelecionarTodosAsync();
            return View(listaUsuario);
        }

        public IActionResult Create()
        {
            return View();
        }

     
        [HttpPost]
        public async Task<IActionResult> Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                await _serviceUsuario.oRepositoryUsuario.IncluirAsync(usuario);
                ViewData["Mensagem"] = "Dados salvos com sucesso.";
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                ViewData["MensagemErro"] = "Ocorreu um erro ao salvar os dados.";
                return View(usuario);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var usuario = await _serviceUsuario.oRepositoryUsuario.SelecionarChaveAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                await _serviceUsuario.oRepositoryUsuario.AlterarAsync(usuario);
                ViewData["Mensagem"] = "Dados alterados com sucesso.";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewData["MensagemErro"] = "Ocorreu um erro ao alterar os dados.";
                return View(usuario);
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            int usuarioLogadoId = ObterUsuarioLogado();
            var usuario = await _serviceUsuario.oRepositoryUsuario.ObterUsuarioPorId(usuarioLogadoId);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _serviceUsuario.oRepositoryUsuario.SelecionarChaveAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            await _serviceUsuario.oRepositoryUsuario.ExcluirAsync(usuario);
            ViewData["Mensagem"] = "Usuário excluído com sucesso.";
            return RedirectToAction(nameof(Index));
        }
        public IActionResult BemVindo()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }


        private int ObterUsuarioLogado()
        {
            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (int.TryParse(userIdString, out int userId))
            {
                return userId;
            }
            return userId;
        }

        [HttpGet]
        public async Task<IActionResult> Perfil()
        {
            int usuarioLogadoId = ObterUsuarioLogado();
            var usuario = await _serviceUsuario.oRepositoryUsuario.ObterUsuarioPorId(usuarioLogadoId);
            return View(usuario);
        }


        [HttpPost]
        public async Task<IActionResult> Perfil(Usuario usuario)
        {
            ModelState.Remove("Id");
            ModelState.Remove("Senha");

            if (ModelState.IsValid)
            {
                await _serviceUsuario.oRepositoryUsuario.AlterarAsync(usuario);
                TempData["Mensagem"] = "Dados alterados com sucesso!";
                return RedirectToAction("HomePage", "iHelpU");
            }
            ModelState.AddModelError("", "Erro ao atualizar os dados.");
            return View(usuario); 
        }

    }
}
