using AutoMapper;
using JogosNet.Data.Dtos.Atendente;
using JogosNet.Models;
using System.Linq;

namespace JogosNet.Profiles
{
    public class AtendenteProfile : Profile
    {
       public AtendenteProfile()
        {
            CreateMap<CreateAtendenteDto, Atendente>();
            CreateMap<Atendente, ReadAtendenteDto>()
                .ForMember(atendente => atendente.Locadoras, opts => opts
                .MapFrom(atendente => atendente.Locadoras.Select
                (c => new { c.Id, c.Nome, c.Endereco, c.EnderecoId })));

        }
    }
}
