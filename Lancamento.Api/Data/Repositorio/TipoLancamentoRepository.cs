using Lancamentos.Api.Data.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Lancamentos.Api.Data.Repositorio
{
    public class TipoLancamentoRepository : ITipoLancamentoRepository
    {
        private readonly LancamentoContext _context;
        public TipoLancamentoRepository(LancamentoContext context)
        {
            _context = context;
        }
        public async Task Atualizar(TipoLancamento entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<TipoLancamento> BuscarPorId(int id)
        {
            return await _context
                    .TiposLancamentos
                    .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<TipoLancamento>> BuscatTodos(int limite = 25, int salto = 0)
        {
            return await _context
                    .TiposLancamentos
                    .Take(limite)
                    .Skip(salto)
                    .ToListAsync();
        }

        public async Task<TipoLancamento> Criar(TipoLancamento entity)
        {
            _context.TiposLancamentos.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Deletar(TipoLancamento entity)
        {
            _context.TiposLancamentos.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Exists(int id)
        {
            return await _context
                    .TiposLancamentos
                    .AsNoTracking()
                    .AnyAsync(p => p.Id == id);
        }
    }
}
