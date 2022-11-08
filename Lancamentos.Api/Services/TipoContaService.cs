using AutoMapper;
using Lancamentos.Api.Data.Entidades;
using Lancamentos.Api.Data.Entidades.DTO;
using Lancamentos.Api.Data.Repositorio;
using Lancamentos.Api.Services;

namespace Contas.Api.Services
{
    public class TipoContaService : ITipoContaService
    {
        private readonly ITipoContaRepository _repo;
        public readonly IMapper _mapper;
        public TipoContaService(ITipoContaRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task Atualizar(TipoContaUpdateDTO dto)
        {
            var obj = await _repo.BuscarPorId(dto.Id);

            _mapper.Map<TipoContaUpdateDTO, TipoConta>(dto, obj);

            await _repo.Atualizar(obj);
        }

        public async Task<TipoContaDTO> BuscarPorId(int id)
        {
            var tipoConta = await _repo.BuscarPorId(id);

            var dto = _mapper.Map<TipoContaDTO>(tipoConta);

            return dto;
        }

        public async Task<IEnumerable<TipoContaDTO>> BuscatTodos(int limite = 25, int salto = 0)
        {
            var list = await _repo.BuscatTodos(limite, salto);

            var dtos = _mapper.Map<IEnumerable<TipoContaDTO>>(list);

            return dtos;
        }

        public async Task<TipoContaDTO> Criar(TipoContaInsertDTO dto)
        {
            var obj = _mapper.Map<TipoConta>(dto);

            obj.Ativo = true;
            obj.DataCriacao = DateTime.Now;

            await _repo.Criar(obj);

            var result = _mapper.Map<TipoContaDTO>(obj);

            return result;
        }

        public async Task<bool> Deletar(int id)
        {
            TipoConta tipoConta = await _repo.BuscarPorId(id);

            if (tipoConta == null)
            {
                return false;
            }

            return await _repo.Deletar(tipoConta);
        }

        public async Task<bool> Exists(int id)
        {
            return await _repo.Exists(id);
        }
    }
}
