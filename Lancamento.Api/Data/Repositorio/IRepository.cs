namespace Lancamento.Api.Data.Repositorio
{
    public interface IRepository<T>
    {
        T BuscarPorId(int id);
        IEnumerable<T> BuscatTodos(int limite = 25, int salto = 0);
        void Atualizar(T entity);
        void Criar(T entity);
        bool Deletar(T entity);
        bool Exists(int id);
    }
}
