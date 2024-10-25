using iHelpU.MODEL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using iHelpU.MODEL.Repositories;
using iHelpU.MODEL.Services;

namespace Projeto_iHelpU.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioService _serviceUsuario;

        // Injeção de dependência do serviço
        public UsuarioController(BancoTccContext context)
        {
            _serviceUsuario = new UsuarioService(context); // Inicializa o serviço com o contexto
           
        }

        // Exibir lista de usuários
        public async Task<IActionResult> Index()
        {
            var listaUsuario = await _serviceUsuario.oRepositoryUsuario.SelecionarTodosAsync();
            return View(listaUsuario);
        }

        // Exibir o formulário de criação de novo usuário
        public IActionResult Create()
        {
            return View();
        }

        // Criação de novo usuário
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

        // Editar usuário
        public async Task<IActionResult> Edit(int id)
        {
            var usuario = await _serviceUsuario.oRepositoryUsuario.SelecionarChaveAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // Salvar as alterações no usuário
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

    }
}
