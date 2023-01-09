using Lancamentos.Api.Data.Entidades;
using Lancamentos.Api.Data.Entidades.DTO;
using Lancamentos.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lancamentos.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _service;

        public UsuariosController(IUsuarioService service)
        {
            _service = service;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> GetUsuarios(int limite = 25, int salto = 0)
        {
            if (limite > 1000)// no maximo 1000 registros por consulta
            {
                limite = 1000;
            }
            var dtos = await _service.BuscatTodos(limite, salto);

            return Ok(dtos);
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDTO>> GetUsuario(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var dto = await _service.BuscarPorId(id);

            if (dto == null)
            {
                return NotFound();
            }

            return dto;
        }

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, UsuarioUpdateDTO dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }

            try
            {
                if (!await UsuarioExists(id))
                {
                    return NotFound();
                }

                await _service.Atualizar(dto);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        // POST: api/Usuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<UsuarioDTO>> PostUsuario(UsuarioInsertDTO dto)
        {

            var result = await _service.Criar(dto);

            return CreatedAtAction("GetUsuario", new { id = result.Id }, result);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            await _service.Deletar(id);

            return NoContent();
        }

        private async Task<bool> UsuarioExists(int id)
        {
            return await _service.Exists(id);
        }

        [HttpPut("{id}/AlterarSenha")]
        public async Task<UsuarioDTO> AlterarSenhaUsario(int id, [FromBody] UsuarioAlterarSenha _user)
        {
            _user.Id = id;

            return await _service.UsuarioAlterarSenha(_user);
        }
    }
}
