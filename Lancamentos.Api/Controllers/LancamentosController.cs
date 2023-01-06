using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lancamentos.Api.Data.Entidades.DTO;
using Lancamentos.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Lancamentos.Api.Essenciais;

namespace Lancamentos.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LancamentosController : ControllerBase
    {
        private readonly ILancamentoService _service;

        public LancamentosController(ILancamentoService service)
        {
            _service = service;
        }

        // GET: api/Lancamentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LancamentoDTO>>> GetLancamentos(int limite = 25, int salto = 0)
        {
            if (limite > 1000)// no maximo 1000 registros por consulta
            {
                limite = 1000;
            }
            var usuarioToken = User.ConvertToken();

            var dtos = await _service.BuscatTodos(usuarioToken.UsuarioId, limite, salto);

            return Ok(dtos);
        }

        // GET: api/Lancamentos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LancamentoDTO>> GetLancamento(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            var usuarioToken = User.ConvertToken();

            var dto = await _service.BuscarPorId(usuarioToken.UsuarioId, id);

            if (dto == null)
            {
                return NotFound();
            }

            return dto;
        }

        // PUT: api/Lancamentos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLancamento(int id, LancamentoUpdateDTO dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }

            try
            {
                if (!await LancamentoExists(id))
                {
                    return NotFound();
                }
                var usuarioToken = User.ConvertToken();

                await _service.Atualizar(usuarioToken.UsuarioId, dto);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        // POST: api/Lancamentos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LancamentoDTO>> PostLancamento(LancamentoInsertDTO dto)
        {
            var result = await _service.Criar(dto);

            return CreatedAtAction("GetLancamento", new { id = result.Id }, result);
        }

        // DELETE: api/Lancamentos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLancamento( int id)
        {
            var usuarioToken = User.ConvertToken();
            await _service.Deletar(usuarioToken.UsuarioId, id);

            return NoContent();
        }

        private async Task<bool> LancamentoExists(int id)
        {
            return await _service.Exists(id);
        }
    }
}
