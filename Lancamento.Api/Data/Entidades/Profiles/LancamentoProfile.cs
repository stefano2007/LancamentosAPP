using AutoMapper;
using Lancamentos.Api.Data.Entidades.DTO;

namespace Lancamentos.Api.Data.Entidades.Profiles
{
    public class LancamentoProfile : Profile
    {
        public LancamentoProfile()
        {
            CreateMap<Lancamento, LancamentoDTO>().ReverseMap();
            CreateMap<Lancamento, LancamentoInsertDTO>().ReverseMap();
            CreateMap<Lancamento, LancamentoUpdateDTO>().ReverseMap();
        }
    }
}
