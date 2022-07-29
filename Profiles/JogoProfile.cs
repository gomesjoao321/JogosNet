using AutoMapper;
using JogosNet.Data.Dtos;
using JogosNet.Models;  

namespace JogosNet.Profiles
{
    public class JogoProfile : Profile
    {
        public JogoProfile()
        {
            CreateMap<CreateJogoDto, Jogo>();
            CreateMap<Jogo, ReadJogoDto>();
            CreateMap<UpdateJogoDto, Jogo>();
        }
    }
}
