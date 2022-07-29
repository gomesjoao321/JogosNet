using AutoMapper;
using JogosNet.Data.Dtos;
using JogosNet.Models;


namespace JogosNet.Profiles
{
    public class LocadoraProfile : Profile
    {
        public LocadoraProfile()
        {
            CreateMap<CreateLocadoraDto, Locadora>();
            CreateMap<Locadora, ReadLocadoraDto>();
            CreateMap<UpdateLocadoraDto, Locadora>();
        }
    }
}
