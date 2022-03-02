using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class UserDto : IDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
