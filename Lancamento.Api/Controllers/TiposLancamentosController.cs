using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lancamento.Api.Data;
using Lancamento.Api.Data.Entidades;
using Lancamento.Api.Data.Repositorio;
using Lancamento.Api.Data.Entidades.DTO;
using AutoMapper;
using Lancamento.Api.Services;

namespace Lancamento.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposLancamentosController : ControllerBase
    {
        private readonly TipoLancamentoService _service;

        public TiposLancamentosController(TipoLancamentoService service)
        {
            _service = service;
        }

        // GET: api/TiposLancamentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoLancamentoDTO>>> GetTiposLancamentos(int limite = 25, int salto = 0)
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
                if (!TipoLancamentoExists(id))
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

        private bool TipoLancamentoExists(int id)
        {
            return _service.Exists(id);
        }
    }
}
