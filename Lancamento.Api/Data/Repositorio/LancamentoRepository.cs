using Lancamento.Api.Data.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Lancamento.Api.Data.Repositorio
{
    public class LancamentoRepository : ILancamentoRepository
    {
        private readonly LancamentoContext _context;
        public LancamentoRepository(LancamentoContext context)
        {
            _context = context;
        }
        public async void Atualizar(ItemLancamento entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<ItemLancamento> BuscarPorId(int id)
        {
            return await _context
                    .Lancamentos
                    .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<ItemLancamento>> BuscatTodos(int limite = 25, int salto = 0)
        {
            return await _context
                    .Lancamentos
                    .Take(limite)
                    .Skip(salto)
                    .ToListAsync();
        }

        public async Task<ItemLancamento> Criar(ItemLancamento entity)
        {
            _context.Lancamentos.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public bool Deletar(ItemLancamento entity)
        {
            _context.Lancamentos.Remove(entity);
            return _context.SaveChanges() > 0;
        }
        public bool Exists(int id)
        {
            return _context
                    .Lancamentos
                    .Any(p => p.Id == id);
        }
    }
}
