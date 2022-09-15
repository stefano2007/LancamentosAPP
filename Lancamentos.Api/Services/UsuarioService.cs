using AutoMapper;
using Lancamentos.Api.Data.Entidades;
using Lancamentos.Api.Data.Entidades.DTO;
using Lancamentos.Api.Data.Repositorio;

namespace Lancamentos.Api.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repo;
        public readonly IMapper _mapper;
        public UsuarioService(IUsuarioRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task Atualizar(UsuarioUpdateDTO dto)
        {
            var obj = await _repo.BuscarPorId(dto.Id);

            _mapper.Map<UsuarioUpdateDTO, Usuario>(dto, obj);

            await _repo.Atualizar(obj);
        }

        public async Task<UsuarioDTO> BuscarPorId(int id)
        {
            var Usuario = await _repo.BuscarPorId(id);

            var dto = _mapper.Map<UsuarioDTO>(Usuario);

            return dto;
        }

        public async Task<IEnumerable<UsuarioDTO>> BuscatTodos(int limite = 25, int salto = 0)
        {
            var list = await _repo.BuscatTodos(limite, salto);

            var dtos = _mapper.Map<IEnumerable<UsuarioDTO>>(list);

            return dtos;
        }

        public async Task<UsuarioDTO> Criar(UsuarioInsertDTO dto)
        {
            var obj = _mapper.Map<Usuario>(dto);

            obj.Ativo = true;
            obj.DataCriacao = DateTime.Now;

            await _repo.Criar(obj);

            var result = _mapper.Map<UsuarioDTO>(obj);

            return result;
        }

        public async Task<bool> Deletar(int id)
        {
            Usuario Usuario = await _repo.BuscarPorId(id);

            if (Usuario == null)
            {
                return false;
            }

            return await _repo.Deletar(Usuario);
        }

        public async Task<bool> Exists(int id)
        {
            return await _repo.Exists(id);
        }
    }
}
