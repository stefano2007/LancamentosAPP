namespace Lancamento.Api.Services
{
    public interface IService
    {
        Task <dynamic> BuscarPorId(int id);
        Task <IEnumerable<dynamic>> BuscatTodos(int limite = 25, int salto = 0);
        void Atualizar(object entity);
        Task <dynamic> Criar(dynamic entity);
        bool Deletar(int id);
        bool Exists(int id);
    }
}
