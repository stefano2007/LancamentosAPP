namespace Lancamentos.Api.Data.Repositorio
{
    public interface IRepositoryUsuarioLogado<T>
    {
        Task <T> BuscarPorId(int usuarioId, int id);
        Task <IEnumerable<T>> BuscatTodos(int usuarioId, int limite = 25, int salto = 0);
        Task Atualizar(int usuarioId, T entity);
        Task<bool> Deletar(int usuarioId, T entity);
        Task <T> Criar(T entity);
        Task<bool> Exists(int id);
    }
}
