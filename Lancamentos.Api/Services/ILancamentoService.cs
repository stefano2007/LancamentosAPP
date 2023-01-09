using Lancamentos.Api.Data.Entidades.DTO;

namespace Lancamentos.Api.Services
{
    public interface ILancamentoService : IServiceUsuarioLogado<LancamentoDTO, LancamentoInsertDTO, LancamentoUpdateDTO>
    {
        Task<IEnumerable<LancamentoDTO>> GetLancamentosPorMesAno(int usuarioId, int mes, int ano);
        Task<IEnumerable<LancamentoDTO>> GetLancamentosPorAno(int usuarioId, int mes);
    }
}
