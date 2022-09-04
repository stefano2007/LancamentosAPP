using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lancamento.Api.Data;
using Lancamento.Api.Data.Entidades;

namespace Lancamento.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemLancamentosController : ControllerBase
    {
        private readonly LancamentoContext _context;

        public ItemLancamentosController(LancamentoContext context)
        {
            _context = context;
        }

        // GET: api/ItemLancamentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemLancamento>>> GetLancamentos()
        {
          if (_context.Lancamentos == null)
          {
              return NotFound();
          }
            return await _context.Lancamentos.ToListAsync();
        }

        // GET: api/ItemLancamentos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemLancamento>> GetItemLancamento(int id)
        {
          if (_context.Lancamentos == null)
          {
              return NotFound();
          }
            var itemLancamento = await _context.Lancamentos.FindAsync(id);

            if (itemLancamento == null)
            {
                return NotFound();
            }

            return itemLancamento;
        }

        // PUT: api/ItemLancamentos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemLancamento(int id, ItemLancamento itemLancamento)
        {
            if (id != itemLancamento.Id)
            {
                return BadRequest();
            }

            _context.Entry(itemLancamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemLancamentoExists(id))
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

        // POST: api/ItemLancamentos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ItemLancamento>> PostItemLancamento(ItemLancamento itemLancamento)
        {
          if (_context.Lancamentos == null)
          {
              return Problem("Entity set 'LancamentoContext.Lancamentos'  is null.");
          }
            _context.Lancamentos.Add(itemLancamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItemLancamento", new { id = itemLancamento.Id }, itemLancamento);
        }

        // DELETE: api/ItemLancamentos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemLancamento(int id)
        {
            if (_context.Lancamentos == null)
            {
                return NotFound();
            }
            var itemLancamento = await _context.Lancamentos.FindAsync(id);
            if (itemLancamento == null)
            {
                return NotFound();
            }

            _context.Lancamentos.Remove(itemLancamento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemLancamentoExists(int id)
        {
            return (_context.Lancamentos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
