using Lancamentos.Api.Data.Entidades.DTO;

namespace Lancamentos.Api.Services
{
    public interface IContaService : IServiceUsuarioLogado<ContaDTO, ContaInsertDTO, ContaUpdateDTO>
    {
    }
}
