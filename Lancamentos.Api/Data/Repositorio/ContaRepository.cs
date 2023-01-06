using Lancamentos.Api.Data.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Lancamentos.Api.Data.Repositorio
{
    public class ContaRepository : IContaRepository
    {
        private readonly LancamentoContext _context;
        public ContaRepository(LancamentoContext context)
        {
            _context = context;
        }

        public async Task Atualizar(int usuarioId, Conta entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Conta> BuscarPorId(int usuarioId, int id)
        {
            return await _context
                    .Contas
                    .Where(x => x.UsuarioId == usuarioId)
                    .Include(l => l.Usuario)
                    .Include(l => l.TipoConta)
                    .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Conta>> BuscatTodos(int usuarioId, int limite = 25, int salto = 0)
        {
            return await _context
                    .Contas
                    .Where(x => x.UsuarioId == usuarioId)
                    .Include(l => l.Usuario)
                    .Include(l => l.TipoConta)
                    .Take(limite)
                    .Skip(salto)
                    .ToListAsync();
        }

        public async Task<Conta> Criar(Conta entity)
        {
            _context.Contas.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Deletar(int usuarioId, Conta entity)
        {
            _context.Contas.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> Exists(int id)
        {
            return await _context
                    .Contas
                    .AnyAsync(p => p.Id == id);
        }
    }
}
