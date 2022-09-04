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

namespace Lancamento.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposLancamentosController : ControllerBase
    {
        private readonly ITipoLancamentoRepository _repo;

        public TiposLancamentosController(ITipoLancamentoRepository repo)
        {
            _repo = repo;
        }

        // GET: api/TiposLancamentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoLancamento>>> GetTiposLancamentos()
        {
            return  Ok(await _repo.BuscatTodos());
        }

        // GET: api/TiposLancamentos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoLancamento>> GetTipoLancamento(int id)
        {
          if (id <= 0)
          {
              return NotFound();
          }
            var tipoLancamento = await _repo.BuscarPorId(id);

            if (tipoLancamento == null)
            {
                return NotFound();
            }

            return tipoLancamento;
        }

        // PUT: api/TiposLancamentos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoLancamento(int id, TipoLancamento tipoLancamento)
        {
            if (id != tipoLancamento.Id)
            {
                return BadRequest();
            }            

            try
            {
                if (!TipoLancamentoExists(id))
                {
                    return BadRequest();
                }

                _repo.Atualizar(tipoLancamento);
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
        public async Task<ActionResult<TipoLancamento>> PostTipoLancamento(TipoLancamento tipoLancamento)
        {
          if (_repo == null)
          {
              return Problem("Entity set 'LancamentoContext.TiposLancamentos'  is null.");
          }
            await _repo.Criar(tipoLancamento);

            return CreatedAtAction("GetTipoLancamento", new { id = tipoLancamento.Id }, tipoLancamento);
        }

        // DELETE: api/TiposLancamentos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoLancamento(int id)
        {
            if (_repo == null)
            {
                return NotFound();
            }
            var tipoLancamento = await _repo.BuscarPorId(id);
            if (tipoLancamento == null)
            {
                return NotFound();
            }

            _repo.Deletar(tipoLancamento);

            return NoContent();
        }

        private bool TipoLancamentoExists(int id)
        {
            return _repo.Exists(id);
        }
    }
}
