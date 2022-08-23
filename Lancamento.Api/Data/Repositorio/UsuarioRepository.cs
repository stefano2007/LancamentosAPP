using Lancamento.Api.Data.Entidades;

namespace Lancamento.Api.Data.Repositorio
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly LancamentoContext _context;
        public UsuarioRepository(LancamentoContext context)
        {
            _context = context;
        }
        public void Atualizar(Usuario entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }

        public Usuario BuscarPorId(int id)
        {
            return _context
                    .Usuarios
                    .FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Usuario> BuscatTodos(int limite = 25, int salto = 0)
        {
            return _context
                    .Usuarios
                    .Take(limite)
                    .Skip(salto)
                    .ToList();
        }

        public void Criar(Usuario entity)
        {
            _context.Usuarios.Add(entity);
            _context.SaveChanges();
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
