using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuarioNet.Data.Usuario;
using UsuarioNet.Models;

namespace UsuarioNet.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CreateUsuarioDto, Usuario>();
            CreateMap<Usuario, IdentityUser<int>>();
            CreateMap<Usuario, CustomIdentityUser>();
        }
    }
}
