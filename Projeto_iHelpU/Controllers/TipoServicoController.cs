using iHelpU.MODEL.Models;
using iHelpU.MODEL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using iHelpU.MODEL.Interface_Services;
using iHelpU.MODEL.Services;

namespace Projeto_iHelpU.Controllers
{
    public class TipoServicoController : Controller
    {
        private BancoTccContext _context;
        private TipoServicoService _serviceTipoServico;
        private RepositoryTipoServico oRepositoryTipoServico;

        // Injeção de dependência do contexto e do service
        public TipoServicoController(BancoTccContext context)
        {
            _context = context;
            _serviceTipoServico = new TipoServicoService(context);  
        }

        // Listar todos os tipos de serviço
        public async Task<IActionResult> Index()
        {
            var listaTipoServico = await _serviceTipoServico.oRepositoryTipoServico.SelecionarTodosAsync();
            return View(listaTipoServico);
        }

        // Exibir o formulário de criação
        public IActionResult Create()
        {
            return View();
        }

        // Criação de novo tipo de serviço
        [HttpPost]
        public async Task<IActionResult> Create(TipoServico tipoServico)
        {
            if (ModelState.IsValid)
            {
                await _serviceTipoServico.oRepositoryTipoServico.IncluirAsync(tipoServico);
                ViewData["Mensagem"] = "Dados salvos com sucesso.";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewData["MensagemErro"] = "Ocorreu um erro ao salvar os dados.";
                return View(tipoServico);
            }
        }

        // Editar um tipo de serviço (busca pelo id) -> Bem possível que não vamos deixar passar pra versão final
        public async Task<IActionResult> Edit(int id)
        {
            var tipoServico = await _serviceTipoServico.oRepositoryTipoServico.SelecionarChaveAsync(id);
            if (tipoServico == null)
            {
                return NotFound();
            }
            return View(tipoServico);
        }

        // Salvar as alterações no tipo de serviço
        [HttpPost]
        public async Task<IActionResult> Edit(TipoServico tipoServico)
        {
            if (ModelState.IsValid)
            {
                await _serviceTipoServico.oRepositoryTipoServico.AlterarAsync(tipoServico);
                ViewData["Mensagem"] = "Dados alterados com sucesso.";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewData["MensagemErro"] = "Ocorreu um erro ao alterar os dados.";
                return View(tipoServico);
            }
        }

        // Exibir os detalhes de um tipo de serviço
        public async Task<IActionResult> Details(int id) // -> Desnecessário
        {
            var tipoServico = await _serviceTipoServico.oRepositoryTipoServico.SelecionarChaveAsync(id);
            if (tipoServico == null)
            {
                return NotFound();
            }
            return View(tipoServico);
        } 

        // Exibir o formulário de exclusão
        public async Task<IActionResult> Delete(int id) // -> Não passa para o usuário final
        {
            var tipoServico = await _serviceTipoServico.oRepositoryTipoServico.SelecionarChaveAsync(id);
            if (tipoServico == null)
            {
                return NotFound();
            }
            return View(tipoServico);
        }

        // Confirmar e excluir o tipo de serviço -> Também não passa para o usuário final
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoServico = await _serviceTipoServico.oRepositoryTipoServico.SelecionarChaveAsync(id);
            if (tipoServico == null)
            {
                ViewData["Mensagem"] = "Ocorreu um problema.";
                return NotFound();
            }

            await _serviceTipoServico.oRepositoryTipoServico.ExcluirAsync(tipoServico);
            ViewData["Mensagem"] = "Dados excluídos com sucesso.";
            return RedirectToAction(nameof(Index));
        }
    }
}



