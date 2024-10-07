using iHelpU.MODEL.Models;
using iHelpU.MODEL.Services;
using iHelpU.MODEL.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace iHelpU.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetenciaController : ControllerBase
    {
        private readonly CompetenciaService _service;

        public CompetenciaController(CompetenciaService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var listaCompetencia = await _service.oRepositoryCompetencia.SelecionarTodosAsync();
            return Ok(listaCompetencia);
        }

        [HttpGet("GetCompetenciaById/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var competencia = await _service.oRepositoryCompetencia.SelecionarChaveAsync(id);
            if (competencia == null)
            {
                return NotFound("Competência não encontrada.");
            }
            return Ok(competencia);
        }


        [HttpPost("PostCompetencia")]
        public async Task<IActionResult> Post(Competencia competencia)
        {
            await _service.CreateAsync(competencia);
            return Ok("Competência cadastrada com sucesso.");
        }

        [HttpPut("PutCompetencia")]
        public async Task<IActionResult> Put(Competencia competencia)
        {
            await _service.UpdateAsync(competencia);
            return Ok("Competência atualizada com sucesso.");
        }


        [HttpDelete("DeleteCompetencia/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.oRepositoryCompetencia.ExcluirAsync(id);
                return Ok("Competência excluída com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
