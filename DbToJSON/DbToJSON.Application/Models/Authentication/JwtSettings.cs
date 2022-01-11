using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbToJSON.Application.Models.Authentication;

namespace DbToJSON.Application.Models.Authentication
{
    public class JwtSettings
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
    }
}
