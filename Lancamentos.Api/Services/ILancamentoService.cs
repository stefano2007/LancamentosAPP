using Lancamentos.Api.Data.Entidades.DTO;

namespace Lancamentos.Api.Services
{
    public interface ILancamentoService : IServiceUsuarioLogado<LancamentoDTO, LancamentoInsertDTO, LancamentoUpdateDTO>
    {
    }
}
