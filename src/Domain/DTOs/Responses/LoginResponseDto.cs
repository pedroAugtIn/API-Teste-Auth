using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.DTOs.Responses
{
    public class LoginResponseDto
    {
        public string JwtToken { get; set; }
    }
}