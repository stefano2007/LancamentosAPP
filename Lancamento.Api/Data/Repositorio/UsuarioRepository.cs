using Lancamento.Api.Data.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Lancamento.Api.Data.Repositorio
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly LancamentoContext _context;
        public UsuarioRepository(LancamentoContext context)
        {
            _context = context;
        }
        public async void Atualizar(Usuario entity)
        {
            _context.Usuarios.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Usuario> BuscarPorId(int id)
        {
            return await _context
                    .Usuarios
                    .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Usuario>> BuscatTodos(int limite = 25, int salto = 0)
        {
            return await _context
                    .Usuarios
                    .Take(limite)
                    .Skip(salto)
                    .ToListAsync();
        }

        public async Task<Usuario> Criar(Usuario entity)
        {
            _context.Usuarios.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public bool Deletar(Usuario entity)
        {
            _context.Usuarios.Remove(entity);
            return _context.SaveChanges() > 0;
        }
        public bool Exists(int id)
        {
            return _context
                    .Usuarios
                    .Any(p => p.Id == id);
        }
    }
}
