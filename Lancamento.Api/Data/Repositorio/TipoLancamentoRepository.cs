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
            _context.Update(entity);
            _context.SaveChanges();
        }

        public TipoLancamento BuscarPorId(int id)
        {
            return _context
                    .TiposLancamentos
                    .FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<TipoLancamento> BuscatTodos(int limite = 25, int salto = 0)
        {
            return _context
                    .TiposLancamentos
                    .Take(limite)
                    .Skip(salto)
                    .ToList();
        }

        public void Criar(TipoLancamento entity)
        {
            _context.TiposLancamentos.Add(entity);
            _context.SaveChanges();
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
                    .Any(p => p.Id == id);
        }
    }
}
