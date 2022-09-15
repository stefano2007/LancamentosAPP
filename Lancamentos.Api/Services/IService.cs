namespace Lancamentos.Api.Services
{
    public interface IService<T, I, U> 
            where T : class 
            where I : class
            where U : class
    {
        Task <T> BuscarPorId(int id);
        Task <IEnumerable<T>> BuscatTodos(int limite = 25, int salto = 0);
        Task Atualizar(U entity);
        Task <T> Criar(I entity);
        Task<bool> Deletar(int id);
        Task<bool> Exists(int id);
    }
}
