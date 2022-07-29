using Microsoft.AspNetCore.Identity;
using System;

namespace UsuarioNet.Models
{

    public class CustomIdentityUser : IdentityUser<int>
    {
        public DateTime DataNascimento { get; set; }
    }
}
