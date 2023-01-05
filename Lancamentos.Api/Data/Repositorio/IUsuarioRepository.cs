using Lancamentos.Api.Data.Entidades;

namespace Lancamentos.Api.Data.Repositorio
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Usuario> GetUsuarioLogin(UsuarioLogin _user);
        Task<Usuario> GetUsuarioByEmail(string email);
    }
}
