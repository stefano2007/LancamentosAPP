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
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _repo;

        public UsuariosController(IUsuarioRepository repo)
        {
            _repo = repo;
        }

        // GET: api/TiposLancamentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetTiposLancamentos()
        {
            return Ok(await _repo.BuscatTodos());
        }

        // GET: api/TiposLancamentos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            var usuario = await _repo.BuscarPorId(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // PUT: api/TiposLancamentos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }

            try
            {
                if (!UsuarioExists(id))
                {
                    return BadRequest();
                }

                _repo.Atualizar(usuario);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
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
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            if (_repo == null)
            {
                return Problem("Entity set 'LancamentoContext.TiposLancamentos'  is null.");
            }
            await _repo.Criar(usuario);

            return CreatedAtAction("GetUsuario", new { id = usuario.Id }, usuario);
        }

        // DELETE: api/TiposLancamentos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            if (_repo == null)
            {
                return NotFound();
            }
            var usuario = await _repo.BuscarPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _repo.Deletar(usuario);

            return NoContent();
        }

        private bool UsuarioExists(int id)
        {
            return _repo.Exists(id);
        }
    }
}
