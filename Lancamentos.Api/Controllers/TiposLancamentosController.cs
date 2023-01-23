using Lancamentos.Api.Data.Entidades.DTO;
using Lancamentos.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lancamentos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposLancamentosController : ControllerBase
    {
        private readonly ITipoLancamentoService _service;

        public TiposLancamentosController(ITipoLancamentoService service)
        {
            _service = service;
        }

        // GET: api/TiposLancamentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoLancamentoDTO>>> GetTiposLancamentos(int limite = 100, int salto = 0)
        {
            if (limite > 1000)// no maximo 1000 registros por consulta
            {
                limite = 1000;
            }
            var dtos = await _service.BuscatTodos(limite, salto);

            return Ok(dtos);
        }

        // GET: api/TiposLancamentos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoLancamentoDTO>> GetTipoLancamento(int id)
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

        // PUT: api/TiposLancamentos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoLancamento(int id, TipoLancamentoUpdateDTO dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }

            try
            {
                await _service.Atualizar(dto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! await TipoLancamentoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TiposLancamentos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoLancamentoDTO>> PostTipoLancamento(TipoLancamentoInsertDTO dto)
        {

            var result = await _service.Criar(dto);

            return CreatedAtAction("GetTipoLancamento", new { id = result.Id }, result);
        }

        // DELETE: api/TiposLancamentos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoLancamento(int id)
        {
            await _service.Deletar(id);

            return NoContent();
        }

        private async Task<bool> TipoLancamentoExists(int id)
        {
            return await _service.Exists(id);
        }
    }
}
