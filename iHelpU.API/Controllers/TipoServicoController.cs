using iHelpU.MODEL.Models;  
using iHelpU.MODEL.Services;
using iHelpU.MODEL.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace iHelpU.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoServicoController : ControllerBase
    {
        private BancoTccContext _context;
        private TipoServicoService _service;

        // Construtor com injeção de dependência
        public TipoServicoController(BancoTccContext context)
        {
            _context = context;
            _service = new TipoServicoService(_context);
        }

        // GET: api/TipoServico
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.oRepositoryTipoServico.SelecionarTodosAsync());
        }

        // GET: api/TipoServico/GetTipoServicoById/{id}
        [HttpGet("GetTipoServicoById/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var tipoServico = await _service.oRepositoryTipoServico.SelecionarChaveAsync(id);
            if (tipoServico == null)
            {
                return NotFound("Tipo de Serviço não encontrado.");
            }
            return Ok(tipoServico);
        }

        // POST: api/TipoServico/PostTipoServico
        [HttpPost("PostTipoServico")]
        public async Task<IActionResult> Post(TipoServico tipoServico)
        {
            await _service.CreateAsync(tipoServico);
            return Ok("Tipo de Serviço cadastrado com sucesso.");
        }

        // PUT: api/TipoServico/PutTipoServico
        [HttpPut("PutTipoServico")]
        public async Task<IActionResult> Put(TipoServico tipoServico)
        {
            await _service.UpdateAsync(tipoServico);
            return Ok("Tipo de Serviço atualizado com sucesso.");
        }

        // DELETE: api/TipoServico/DeleteTipoServico/{id}
        [HttpDelete("DeleteTipoServico/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.oRepositoryTipoServico.ExcluirAsync(id);
                return Ok("Tipo de Serviço excluído com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

