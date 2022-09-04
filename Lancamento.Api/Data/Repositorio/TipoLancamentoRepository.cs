using Lancamento.Api.Data.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Lancamento.Api.Data.Repositorio
{
    public class TipoLancamentoRepository : ITipoLancamentoRepository
    {
        private readonly LancamentoContext _context;
        public TipoLancamentoRepository(LancamentoContext context)
        {
            _context = context;
        }
        public void Atualizar(TipoLancamento entity)
        {
            _context.TiposLancamentos.Add(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
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

        public bool Deletar(TipoLancamento entity)
        {
            _context.TiposLancamentos.Remove(entity);
            return _context.SaveChanges() > 0;
        }

        public bool Exists(int id)
        {
            return _context
                    .TiposLancamentos
                    .AsNoTracking()
                    .Any(p => p.Id == id);
        }
    }
}
