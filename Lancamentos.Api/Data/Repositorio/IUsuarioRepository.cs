using Lancamentos.Api.Data.Entidades;
using Lancamentos.Api.Data.Entidades.DTO;

namespace Lancamentos.Api.Data.Repositorio
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Usuario> GetUsuarioLogin(UsuarioLogin _user);
    }
}
