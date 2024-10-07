using iHelpU.MODEL.Models;
using iHelpU.MODEL.Services;
using iHelpU.MODEL.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using iHelpU.MODEL.Interface_Services;

namespace iHelpU.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvaliacaoController : ControllerBase
    {
        private readonly Avaliacao_Service _service;

        // Construtor com injeção de dependência
        public AvaliacaoController(Avaliacao_Service service)
        {
            _service = service;
        }

        // GET: api/Avaliacao
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var listaAvaliacao = await _service.oRepositoryAvaliacao.SelecionarTodosAsync();
            return Ok(listaAvaliacao);
        }

        // GET: api/Avaliacao/GetAvaliacaoById/{id}
        [HttpGet("GetAvaliacaoById/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var avaliacao = await _service.oRepositoryAvaliacao.SelecionarChaveAsync(id);
            if (avaliacao == null)
            {
                return NotFound("Avaliação não encontrada.");
            }
            return Ok(avaliacao);
        }

        // POST: api/Avaliacao/PostAvaliacao
        [HttpPost("PostAvaliacao")]
        public async Task<IActionResult> Post(Avaliacao avaliacao)
        {
            await _service.CreateAsync(avaliacao);
            return Ok("Avaliação cadastrada com sucesso.");
        }

        // PUT: api/Avaliacao/PutAvaliacao
        [HttpPut("PutAvaliacao")]
        public async Task<IActionResult> Put(Avaliacao avaliacao)
        {
            await _service.UpdateAsync(avaliacao);
            return Ok("Avaliação atualizada com sucesso.");
        }

        // DELETE: api/Avaliacao/DeleteAvaliacao/{id}
        [HttpDelete("DeleteAvaliacao/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.oRepositoryAvaliacao.ExcluirAsync(id);
                return Ok("Avaliação excluída com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
