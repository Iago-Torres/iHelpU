using iHelpU.MODEL.Models;
using iHelpU.MODEL.Services;
using iHelpU.MODEL.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace iHelpU.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _service;

        // Construtor com injeção de dependência
        public UsuarioController(UsuarioService service)
        {
            _service = service;
        }

        // GET: api/Usuario
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var listaUsuario = await _service.oRepositoryUsuario.SelecionarTodosAsync();
            return Ok(listaUsuario);
        }

        // GET: api/Usuario/GetUsuarioById/{id}
        [HttpGet("GetUsuarioById/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var usuario = await _service.oRepositoryUsuario.SelecionarChaveAsync(id);
            if (usuario == null)
            {
                return NotFound("Usuário não encontrado.");
            }
            return Ok(usuario);
        }

        // POST: api/Usuario/PostUsuario
        [HttpPost("PostUsuario")]
        public async Task<IActionResult> Post(Usuario usuario)
        {
            await _service.CreateAsync(usuario);
            return Ok("Usuário cadastrado com sucesso.");
        }

        // PUT: api/Usuario/PutUsuario
        [HttpPut("PutUsuario")]
        public async Task<IActionResult> Put(Usuario usuario)
        {
            await _service.UpdateAsync(usuario);
            return Ok("Usuário atualizado com sucesso.");
        }

        // DELETE: api/Usuario/DeleteUsuario/{id}
        [HttpDelete("DeleteUsuario/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.oRepositoryUsuario.ExcluirAsync(id);
                return Ok("Usuário excluído com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
