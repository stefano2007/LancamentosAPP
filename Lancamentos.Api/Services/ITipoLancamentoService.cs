using Lancamentos.Api.Data.Entidades.DTO;

namespace Lancamentos.Api.Services
{
    public interface ITipoLancamentoService : IService<TipoLancamentoDTO, TipoLancamentoInsertDTO, TipoLancamentoUpdateDTO>
    {
        //Task<TipoLancamentoDTO> BuscarPorId(int id);
        //Task<IEnumerable<TipoLancamentoDTO>> BuscatTodos(int limite = 25, int salto = 0);
        //Task Atualizar(TipoLancamentoUpdateDTO entity);
        //Task<TipoLancamentoDTO> Criar(TipoLancamentoInsertDTO entity);

        //Task<bool> Deletar(int id);
        //Task<bool> Exists(int id);

    }
}
