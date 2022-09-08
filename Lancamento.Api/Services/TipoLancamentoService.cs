using AutoMapper;
using Lancamentos.Api.Data.Entidades;
using Lancamentos.Api.Data.Entidades.DTO;
using Lancamentos.Api.Data.Repositorio;

namespace Lancamentos.Api.Services
{
    public class TipoLancamentoService : ITipoLancamentoService
    {
        private readonly ITipoLancamentoRepository _repo;
        public readonly IMapper _mapper;
        public TipoLancamentoService(ITipoLancamentoRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task Atualizar(TipoLancamentoUpdateDTO dto)
        {
            var obj = await _repo.BuscarPorId(dto.Id);

            _mapper.Map<TipoLancamentoUpdateDTO, TipoLancamento>(dto, obj);

            await _repo.Atualizar(obj);
        }

        public async Task<TipoLancamentoDTO> BuscarPorId(int id)
        {
            var tipoLancamento = await _repo.BuscarPorId(id);

            var dto = _mapper.Map<TipoLancamentoDTO>(tipoLancamento);

            return dto;
        }

        public async Task<IEnumerable<TipoLancamentoDTO>> BuscatTodos(int limite = 25, int salto = 0)
        {
            var list = await _repo.BuscatTodos(limite, salto);

            var dtos = _mapper.Map<IEnumerable<TipoLancamentoDTO>>(list);

            return dtos;
        }

        public async Task<TipoLancamentoDTO> Criar(TipoLancamentoInsertDTO dto)
        {
            var obj = _mapper.Map<TipoLancamento>(dto);

            obj.Ativo = true;
            obj.DataCriacao = DateTime.Now;

            await _repo.Criar(obj);

            var result = _mapper.Map<TipoLancamentoDTO>(obj);

            return result;
        }

        public async Task<bool> Deletar(int id)
        {
            TipoLancamento tipoLancamento = await _repo.BuscarPorId(id);

            if (tipoLancamento == null)
            {
                return false;
            }

            return await _repo.Deletar(tipoLancamento);
        }

        public async Task<bool> Exists(int id)
        {
            return await _repo.Exists(id);
        }
    }
}
