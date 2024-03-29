﻿using Lancamentos.Api.Data.Entidades.DTO;
using Lancamentos.Api.Essenciais;
using Lancamentos.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lancamentos.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ContasController : ControllerBase
    {
        private readonly IContaService _service;

        public ContasController(IContaService service)
        {
            _service = service;
        }

        // GET: api/Contas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContaDTO>>> GetContas(int limite = 100, int salto = 0)
        {
            var usuarioToken = User.ConvertToken();

            if (limite > 1000)// no maximo 1000 registros por consulta
            {
                limite = 1000;
            }
            var dtos = await _service.BuscatTodos(usuarioToken.UsuarioId, limite, salto);

            return Ok(dtos);
        }

        // GET: api/Contas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContaDTO>> GetConta(int id)
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

        // PUT: api/Contas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConta(int id, ContaUpdateDTO dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }

            try
            {
                var usuarioToken = User.ConvertToken();

                if (!await ContaExists(id))
                {
                    return NotFound();
                }

                await _service.Atualizar(usuarioToken.UsuarioId, dto);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        // POST: api/Contas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContaDTO>> PostConta(ContaInsertDTO dto)
        {
            var result = await _service.Criar(dto);

            return CreatedAtAction("GetConta", new { id = result.Id }, result);
        }

        // DELETE: api/Contas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConta(int id)
        {
            var usuarioToken = User.ConvertToken();

            await _service.Deletar(usuarioToken.UsuarioId, id);

            return NoContent();
        }
        
        private async Task<bool> ContaExists(int id)
        {
            return await _service.Exists(id);
        }
    }
}
