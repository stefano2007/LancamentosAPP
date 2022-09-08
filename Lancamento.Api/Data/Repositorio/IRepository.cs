namespace Lancamentos.Api.Data.Repositorio
{
    public interface IRepository<T>
    {
        Task <T> BuscarPorId(int id);
        Task <IEnumerable<T>> BuscatTodos(int limite = 25, int salto = 0);
        Task Atualizar(T entity);
        Task <T> Criar(T entity);
        Task<bool> Deletar(T entity);
        Task<bool> Exists(int id);
    }
}
