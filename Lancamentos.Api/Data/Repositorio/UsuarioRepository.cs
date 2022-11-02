using Lancamentos.Api.Data.Entidades;
using Lancamentos.Api.Data.Entidades.DTO;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Lancamentos.Api.Data.Repositorio
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly LancamentoContext _context;
        public UsuarioRepository(LancamentoContext context)
        {
            _context = context;
        }
        public async Task Atualizar(Usuario entity)
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

        public async Task<bool> Deletar(Usuario entity)
        {
            _context.Usuarios.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> Exists(int id)
        {
            return await _context
                    .Usuarios
                    .AnyAsync(p => p.Id == id);
        }

        public async Task<Usuario> GetUsuarioLogin(UsuarioLogin _user)
        {
            return await _context
                    .Usuarios
                    .AsNoTracking()
                    .FirstOrDefaultAsync(u => u.Email == _user.Email && u.Senha == _user.Senha);
        }

    }
}
