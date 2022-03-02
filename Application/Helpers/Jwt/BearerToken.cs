using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers.Jwt
{
    public class BearerToken : IAccessToken
    {
        public DateTime Expiration { get; set; }
        public string Token { get; set; }
    }
}
