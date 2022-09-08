using AutoMapper;
using Lancamentos.Api.Data.Entidades.DTO;

namespace Lancamentos.Api.Data.Entidades.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioInsertDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioUpdateDTO>().ReverseMap();

        }
    }
}
