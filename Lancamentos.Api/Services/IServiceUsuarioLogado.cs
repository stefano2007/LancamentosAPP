namespace Lancamentos.Api.Services
{
    public interface IServiceUsuarioLogado<T, I, U> 
            where T : class 
            where I : class
            where U : class
    {
        Task <T> BuscarPorId(int usuairoId, int id);
        Task <IEnumerable<T>> BuscatTodos(int usuairoId, int limite = 25, int salto = 0);
        Task Atualizar(int usuairoId, U entity);
        Task <T> Criar(I entity);
        Task<bool> Deletar(int usuairoId, int id);
        Task<bool> Exists(int id);
    }
}
