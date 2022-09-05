using AutoMapper;
using Lancamento.Api.Data.Entidades.DTO;

namespace Lancamento.Api.Data.Entidades.Profiles
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
