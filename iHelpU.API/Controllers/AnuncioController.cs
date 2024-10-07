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
    public class AnuncioServicoController : ControllerBase
    {
        private readonly AnuncioServico_Service _service;

        public AnuncioServicoController(AnuncioServico_Service service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var listaAnuncioServico = await _service.oRepositoryAnuncioServico.SelecionarTodosAsync();
            return Ok(listaAnuncioServico);
        }


        [HttpGet("GetAnuncioServicoById/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var anuncioServico = await _service.oRepositoryAnuncioServico.SelecionarChaveAsync(id);
            if (anuncioServico == null)
            {
                return NotFound("Anúncio de Serviço não encontrado.");
            }
            return Ok(anuncioServico);
        }

        [HttpPost("PostAnuncioServico")]
        public async Task<IActionResult> Post(AnuncioServico anuncioServico)
        {
            await _service.CreateAsync(anuncioServico);
            return Ok("Anúncio de Serviço cadastrado com sucesso.");
        }

        [HttpPut("PutAnuncioServico")]
        public async Task<IActionResult> Put(AnuncioServico anuncioServico)
        {
            await _service.UpdateAsync(anuncioServico);
            return Ok("Anúncio de Serviço atualizado com sucesso.");
        }

        [HttpDelete("DeleteAnuncioServico/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.oRepositoryAnuncioServico.ExcluirAsync(id);
                return Ok("Anúncio de Serviço excluído com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
