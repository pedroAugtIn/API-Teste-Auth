using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.DTOs.Responses
{
    public record ClientResponse(int Id, string Name, string LastName, string PhoneNumber)
    {
        
    }
}