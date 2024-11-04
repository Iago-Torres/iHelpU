using iHelpU.MODEL.Models;
using iHelpU.MODEL.Services;
using iHelpU.MODEL.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace iHelpU.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratacaoServicoController : ControllerBase
    {
        private readonly ContratacaoServicoService _service;


        public ContratacaoServicoController(ContratacaoServicoService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var listaContratacaoServico = await _service.oRepositoryContratacaoServico.SelecionarTodosAsync();
            return Ok(listaContratacaoServico);
        }


        [HttpGet("GetContratacaoServicoById/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var contratacaoServico = await _service.oRepositoryContratacaoServico.SelecionarChaveAsync(id);
            if (contratacaoServico == null)
            {
                return NotFound("Contratação de Serviço não encontrada.");
            }
            return Ok(contratacaoServico);
        }


        [HttpPost("PostContratacaoServico")]
        public async Task<IActionResult> Post(ContratacaoServico contratacaoServico)
        {
            await _service.CreateAsync(contratacaoServico);
            return Ok("Contratação de Serviço cadastrada com sucesso.");
        }

        [HttpPut("PutContratacaoServico")]
        public async Task<IActionResult> Put(ContratacaoServico contratacaoServico)
        {
            await _service.UpdateAsync(contratacaoServico);
            return Ok("Contratação de Serviço atualizada com sucesso.");
        }

        [HttpDelete("DeleteContratacaoServico/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.oRepositoryContratacaoServico.ExcluirAsync(id);
                return Ok("Contratação de Serviço excluída com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
