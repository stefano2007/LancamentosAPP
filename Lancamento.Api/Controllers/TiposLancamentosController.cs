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

namespace Lancamento.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposLancamentosController : ControllerBase
    {
        private readonly ITipoLancamentoRepository _repo;
        public readonly IMapper _mapper;

        public TiposLancamentosController(ITipoLancamentoRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET: api/TiposLancamentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoLancamentoDTO>>> GetTiposLancamentos()
        {

            var list = await _repo.BuscatTodos();

            var dtos = _mapper.Map<IEnumerable<TipoLancamentoDTO>>(list);

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
            var tipoLancamento = await _repo.BuscarPorId(id);

            if (tipoLancamento == null)
            {
                return NotFound();
            }

            var dto = _mapper.Map<TipoLancamentoDTO>(tipoLancamento);

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
                var obj = await _repo.BuscarPorId(id);
                //if (!TipoLancamentoExists(id))
                if (obj == null)
                {
                    return BadRequest();
                }

                _mapper.Map<TipoLancamentoUpdateDTO, TipoLancamento>(dto, obj);

                _repo.Atualizar(obj);
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
            if (_repo == null)
            {
                return Problem("Entity set 'LancamentoContext.TiposLancamentos'  is null.");
            }
            var obj = _mapper.Map<TipoLancamento>(dto);

            obj.Ativo = true;
            obj.DataCriacao = DateTime.Now;

            await _repo.Criar(obj);

            var result = _mapper.Map<TipoLancamentoDTO>(obj);

            return CreatedAtAction("GetTipoLancamento", new { id = result.Id }, result);
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
