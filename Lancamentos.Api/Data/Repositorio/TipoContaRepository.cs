using Lancamentos.Api.Data.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Lancamentos.Api.Data.Repositorio
{
    public class TipoContaRepository : ITipoContaRepository
    {
        private readonly LancamentoContext _context;
        public TipoContaRepository(LancamentoContext context)
        {
            _context = context;
        }

        public async Task Atualizar(TipoConta entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<TipoConta> BuscarPorId(int id)
        {
            return await _context
                    .TiposContas
                    .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<TipoConta>> BuscatTodos(int limite = 25, int salto = 0)
        {
            return await _context
                    .TiposContas
                    .Take(limite)
                    .Skip(salto)
                    .ToListAsync();
        }

        public async Task<TipoConta> Criar(TipoConta entity)
        {
            _context.TiposContas.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Deletar(TipoConta entity)
        {
            _context.TiposContas.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> Exists(int id)
        {
            return await _context
                    .TiposContas
                    .AnyAsync(p => p.Id == id);
        }
    }
}
