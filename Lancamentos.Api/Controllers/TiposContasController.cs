using Lancamentos.Api.Data.Entidades.DTO;
using Lancamentos.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Contas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposContasController : ControllerBase
    {
        private readonly ITipoContaService _service;

        public TiposContasController(ITipoContaService service)
        {
            _service = service;
        }

        // GET: api/TiposContas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoContaDTO>>> GetTiposContas(int limite = 100, int salto = 0)
        {
            if (limite > 1000)// no maximo 1000 registros por consulta
            {
                limite = 1000;
            }
            var dtos = await _service.BuscatTodos(limite, salto);

            return Ok(dtos);
        }

        // GET: api/TiposContas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoContaDTO>> GetTipoConta(int id)
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

        // PUT: api/TiposContas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoConta(int id, TipoContaUpdateDTO dto)
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
                if (! await TipoContaExists(id))
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

        // POST: api/TiposContas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoContaDTO>> PostTipoConta(TipoContaInsertDTO dto)
        {

            var result = await _service.Criar(dto);

            return CreatedAtAction("GetTipoConta", new { id = result.Id }, result);
        }

        // DELETE: api/TiposContas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoConta(int id)
        {
            await _service.Deletar(id);

            return NoContent();
        }

        private async Task<bool> TipoContaExists(int id)
        {
            return await _service.Exists(id);
        }
    }
}
