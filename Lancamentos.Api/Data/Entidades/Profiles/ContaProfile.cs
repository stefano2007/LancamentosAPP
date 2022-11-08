using AutoMapper;
using Lancamentos.Api.Data.Entidades.DTO;

namespace Lancamentos.Api.Data.Entidades.Profiles
{
    public class ContaProfile : Profile
    {
        public ContaProfile()
        {
            CreateMap<Conta, ContaDTO>().ReverseMap();
            CreateMap<Conta, ContaInsertDTO>().ReverseMap();
            CreateMap<Conta, ContaUpdateDTO>().ReverseMap();

        }
    }
}
