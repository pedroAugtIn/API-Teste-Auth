using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DTOs.Entries;
using Domain.DTOs.Responses;

namespace Domain.Interfaces.Services
{
    public interface IClientService
    {
        Task<BaseResponse<ClientResponse>> GetAllAsync();
        Task<BaseResponse<ClientResponse>> GetByIdAsync(int id);
        Task<BaseResponse<ClientResponse>> CreateAsync(ClientEntry client);
        Task<BaseResponse<ClientResponse>> UpdateAsync(int id, ClientEntry client);
        Task<BaseResponse<ClientResponse>> DeleteAsync(int id);
    }
}