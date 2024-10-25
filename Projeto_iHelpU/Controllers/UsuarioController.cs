using iHelpU.MODEL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using iHelpU.MODEL.Services;

namespace Projeto_iHelpU.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioService _serviceUsuario;
        private readonly BancoTccContext _context;

        // Injeção de dependência do contexto e serviço
        public UsuarioController(BancoTccContext context)
        {
            _context = context;
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

        // Detalhes do usuário
        public async Task<IActionResult> Details(int id)
        {
            var usuario = await _serviceUsuario.oRepositoryUsuario.SelecionarChaveAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // Exibir a página de confirmação para excluir um usuário
        public async Task<IActionResult> Delete(int id)
        {
            var usuario = await _serviceUsuario.oRepositoryUsuario.SelecionarChaveAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // Confirmar exclusão do usuário
        [HttpPost, ActionName("Delete")]
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


        public IActionResult ListaUsuarios()
        {
            var usuarios = _serviceUsuario.oRepositoryUsuario
                .ObterTodos()
                .Include(u => u.Competencia) 
                .ToList();
            return View(usuarios);
        }

        public IActionResult CompetenciasPorUsuario(int id)
        {
            var usuario = _serviceUsuario.oRepositoryUsuario
                .ObterTodos()
                .Include(u => u.Competencia) 
                .FirstOrDefault(u => u.Id == id); 

            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }


    }
}
