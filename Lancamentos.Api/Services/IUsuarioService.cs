using Lancamentos.Api.Data.Entidades;
using Lancamentos.Api.Data.Entidades.DTO;

namespace Lancamentos.Api.Services
{
    public interface IUsuarioService : IService<UsuarioDTO, UsuarioInsertDTO, UsuarioUpdateDTO>
    {
        Task<UsuarioLoginDTO> GetUsuarioLogin(UsuarioLogin _user);
    }
}
