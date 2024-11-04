using iHelpU.MODEL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using iHelpU.MODEL.Repositories;
using iHelpU.MODEL.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

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
                return RedirectToAction(nameof(Index));
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
            var usuario = await _serviceUsuario.oRepositoryUsuario.SelecionarChaveAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var usuario = await _serviceUsuario.oRepositoryUsuario.SelecionarChaveAsync(id);
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

        public async Task<IActionResult> Perfil(int usuarioId = 0)
        {
            var usuarios = await _serviceUsuario.oRepositoryUsuario.SelecionarTodosAsync();
            ViewBag.Usuarios = usuarios;

            if (usuarioId == 0)
            {
                
                return View();
            }

            var usuario = await _serviceUsuario.oRepositoryUsuario.ObterUsuarioPorId(usuarioId);
            if (usuario == null)
            {
                return View("Erro"); 
            }

            return View(usuario);
        }

     
        [HttpPost]
        public async Task<IActionResult> UpdateProfile(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                await _serviceUsuario.oRepositoryUsuario.AlterarAsync(usuario);
                return RedirectToAction("Perfil", new { usuarioId = usuario.Id });
            }

           
            var usuarios = await _serviceUsuario.oRepositoryUsuario.SelecionarTodosAsync();
            ViewBag.Usuarios = usuarios;
            return View("Perfil", usuario);
        }
        public async Task<Usuario> ValidarCredenciaisAsync(string email, string senha)
        {
            return await _serviceUsuario.oRepositoryUsuario._context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == email && u.Cpf == senha);
        }
    }
}
