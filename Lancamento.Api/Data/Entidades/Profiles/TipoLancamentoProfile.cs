using AutoMapper;
using Lancamentos.Api.Data.Entidades.DTO;

namespace Lancamentos.Api.Data.Entidades.Profiles
{
    public class TipoLancamentoProfile : Profile
    {
        public TipoLancamentoProfile()
        {
            CreateMap<TipoLancamento, TipoLancamentoDTO>().ReverseMap();
            CreateMap<TipoLancamento, TipoLancamentoInsertDTO>().ReverseMap();
            CreateMap<TipoLancamento, TipoLancamentoUpdateDTO>().ReverseMap();

        }
    }
}
