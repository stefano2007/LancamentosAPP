using AutoMapper;
using Lancamentos.Api.Data.Entidades;
using Lancamentos.Api.Data.Entidades.DTO;
using Lancamentos.Api.Data.Repositorio;

namespace Lancamentos.Api.Services
{
    public class LancamentoService : ILancamentoService
    {
        private readonly ILancamentoRepository _repo;
        public readonly IMapper _mapper;
        public LancamentoService(ILancamentoRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task Atualizar(int usuarioId, LancamentoUpdateDTO dto)
        {
            var obj = await _repo.BuscarPorId(usuarioId, dto.Id);

            _mapper.Map<LancamentoUpdateDTO, Lancamento>(dto, obj);

            await _repo.Atualizar(usuarioId, obj);
        }

        public async Task<LancamentoDTO> BuscarPorId(int usuarioId, int id)
        {
            var Lancamento = await _repo.BuscarPorId(usuarioId, id);

            var dto = _mapper.Map<LancamentoDTO>(Lancamento);

            return dto;
        }

        public async Task<IEnumerable<LancamentoDTO>> BuscatTodos(int usuarioId, int limite = 25, int salto = 0)
        {
            var list = await _repo.BuscatTodos(usuarioId, limite, salto);

            var dtos = _mapper.Map<IEnumerable<LancamentoDTO>>(list);

            return dtos;
        }

        public async Task<LancamentoDTO> Criar(LancamentoInsertDTO dto)
        {
            var obj = _mapper.Map<Lancamento>(dto);

            obj.Ativo = true;
            obj.DataCriacao = DateTime.Now;

            await _repo.Criar(obj);

            var result = _mapper.Map<LancamentoDTO>(obj);

            return result;
        }

        public async Task<bool> Deletar(int usuarioId, int id)
        {
            Lancamento Lancamento = await _repo.BuscarPorId(usuarioId, id);

            if (Lancamento == null)
            {
                return false;
            }

            return await _repo.Deletar(usuarioId, Lancamento);
        }

        public async Task<bool> Exists(int id)
        {
            return await _repo.Exists(id);
        }
    }
}
