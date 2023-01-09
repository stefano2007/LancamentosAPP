using Lancamentos.Api.Data.Entidades;
using Lancamentos.Api.Data.Entidades.DTO;

namespace Lancamentos.Api.Data.Repositorio
{
    public interface ILancamentoRepository : IRepositoryUsuarioLogado<Lancamento>
    {
        Task<IEnumerable<Lancamento>> GetLancamentosPorMesAno(int usuarioId, int mes, int ano);
        Task<IEnumerable<Lancamento>> GetLancamentosPorAno(int usuarioId, int ano);
    }
}
