using Lancamentos.Api.Data.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Lancamentos.Api.Data.Repositorio
{
    public class LancamentoRepository : ILancamentoRepository
    {
        private readonly LancamentoContext _context;
        public LancamentoRepository(LancamentoContext context)
        {
            _context = context;
        }
        public async Task Atualizar(Lancamento entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Lancamento> BuscarPorId(int id)
        {
            return await _context
                    .Lancamentos
                    .Include(l => l.Usuario)
                    .Include(l => l.TipoLancamento)
                    .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Lancamento>> BuscatTodos(int limite = 25, int salto = 0)
        {
            return await _context
                    .Lancamentos
                    .Include(l => l.Usuario)
                    .Include(l => l.TipoLancamento)
                    .Take(limite)
                    .Skip(salto)
                    .ToListAsync();
        }

        public async Task<Entidades.Lancamento> Criar(Entidades.Lancamento entity)
        {
            _context.Lancamentos.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Deletar(Entidades.Lancamento entity)
        {
            _context.Lancamentos.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> Exists(int id)
        {
            return await _context
                    .Lancamentos
                    .AnyAsync(p => p.Id == id);
        }
    }
}
