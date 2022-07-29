using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsuarioNet.Models
{
    public class SecuritySettings
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string SigningKey { get; set; }
        public int HoursToExpire { get; set; }
    }
}
