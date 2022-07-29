using AutoMapper;
using JogosNet.Data.Dtos.Sessao;
using JogosNet.Models;

namespace JogosNet.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<CreateSessaoDto, Sessao>();
            CreateMap<Sessao, ReadSessaoDto>();

        }
    }
}
