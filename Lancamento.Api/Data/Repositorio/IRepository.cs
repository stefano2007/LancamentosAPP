namespace Lancamento.Api.Data.Repositorio
{
    public interface IRepository<T>
    {
        Task <T> BuscarPorId(int id);
        Task <IEnumerable<T>> BuscatTodos(int limite = 25, int salto = 0);
        void Atualizar(T entity);
        Task <T> Criar(T entity);
        bool Deletar(T entity);
        bool Exists(int id);
    }
}
