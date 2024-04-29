using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudPlant.Domain.DTO
{
    public class AuthenticatedUserDTO
    {
        public string Username { get; set; }
        public string Token { get; set; }
    }
}
