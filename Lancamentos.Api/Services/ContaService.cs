using AutoMapper;
using Lancamentos.Api.Data.Entidades;
using Lancamentos.Api.Data.Entidades.DTO;
using Lancamentos.Api.Data.Repositorio;
using Lancamentos.Api.Services;

namespace Contas.Api.Services
{
    public class ContaService : IContaService
    {
        private readonly IContaRepository _repo;
        public readonly IMapper _mapper;
        public ContaService(IContaRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task Atualizar(ContaUpdateDTO dto)
        {
            var obj = await _repo.BuscarPorId(dto.Id);

            _mapper.Map<ContaUpdateDTO, Conta>(dto, obj);

            await _repo.Atualizar(obj);
        }

        public async Task<ContaDTO> BuscarPorId(int id)
        {
            var Conta = await _repo.BuscarPorId(id);

            var dto = _mapper.Map<ContaDTO>(Conta);

            return dto;
        }

        public async Task<IEnumerable<ContaDTO>> BuscatTodos(int limite = 25, int salto = 0)
        {
            var list = await _repo.BuscatTodos(limite, salto);

            var dtos = _mapper.Map<IEnumerable<ContaDTO>>(list);

            return dtos;
        }

        public async Task<ContaDTO> Criar(ContaInsertDTO dto)
        {
            var obj = _mapper.Map<Conta>(dto);

            obj.Ativo = true;
            obj.DataCriacao = DateTime.Now;

            await _repo.Criar(obj);

            var result = _mapper.Map<ContaDTO>(obj);

            return result;
        }

        public async Task<bool> Deletar(int id)
        {
            Conta Conta = await _repo.BuscarPorId(id);

            if (Conta == null)
            {
                return false;
            }

            return await _repo.Deletar(Conta);
        }

        public async Task<bool> Exists(int id)
        {
            return await _repo.Exists(id);
        }
    }
}
