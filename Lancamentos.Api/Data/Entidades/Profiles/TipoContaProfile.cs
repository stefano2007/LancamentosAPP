using AutoMapper;
using Lancamentos.Api.Data.Entidades.DTO;

namespace Lancamentos.Api.Data.Entidades.Profiles
{
    public class TipoContaProfile : Profile
    {
        public TipoContaProfile()
        {
            CreateMap<TipoConta, TipoContaDTO>().ReverseMap();
            CreateMap<TipoConta, TipoContaInsertDTO>().ReverseMap();
            CreateMap<TipoConta, TipoContaUpdateDTO>().ReverseMap();

        }
    }
}
