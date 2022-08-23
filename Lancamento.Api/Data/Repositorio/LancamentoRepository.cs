using Lancamento.Api.Data.Entidades;

namespace Lancamento.Api.Data.Repositorio
{
    public class LancamentoRepository : ILancamentoRepository
    {
        private readonly LancamentoContext _context;
        public LancamentoRepository(LancamentoContext context)
        {
            _context = context;
        }
        public void Atualizar(ItemLancamento entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }

        public ItemLancamento BuscarPorId(int id)
        {
            return _context
                    .Lancamentos
                    .FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<ItemLancamento> BuscatTodos(int limite = 25, int salto = 0)
        {
            return _context
                    .Lancamentos
                    .Take(limite)
                    .Skip(salto)
                    .ToList();
        }

        public void Criar(ItemLancamento entity)
        {
            _context.Lancamentos.Add(entity);
            _context.SaveChanges();
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
