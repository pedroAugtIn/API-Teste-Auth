using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.DTOs.Entries;
using Domain.DTOs.Responses;
using Domain.Interfaces;
using Domain.Interfaces.Services;
using Domain.Models;

namespace Services.Services
{
    public class ClientService(IBaseRepository<ClientEntity> repository, IMapper mapper) : IClientService
    {
        public async Task<BaseResponse<ClientResponse>> CreateAsync(ClientEntry client)
        {
            var newClient = await repository.CreateAsync(mapper.Map<ClientEntity>(client));
            return new BaseResponse<ClientResponse>(true, "Novo Client Adicionado!", mapper.Map<ClientResponse>(newClient));
        }

        public async Task<BaseResponse<ClientResponse>> DeleteAsync(int id)
        {
            var clientDeleted = await repository.DeleteAsync(id);
            return new BaseResponse<ClientResponse>(clientDeleted, "Cliente Deletado Com Sucesso", null);
        }

        public async Task<BaseResponse<ClientResponse>> GetAllAsync()
        {
            var clients = await repository.GetAllAsync();
            var clientsResponse = clients.Select(s => mapper.Map<ClientResponse>(s));
            return new BaseResponse<ClientResponse>(true, "", clientsResponse);

        }

        public async Task<BaseResponse<ClientResponse>> GetByIdAsync(int id)
        {
            var client = await repository.GetByIdAsync(id);
            return new BaseResponse<ClientResponse>(true, "", mapper.Map<ClientResponse>(client));

        }

        public async Task<BaseResponse<ClientResponse>> UpdateAsync(int id, ClientEntry client)
        {
            var clientEntity = mapper.Map<ClientEntity>(client);
            clientEntity.Id = id;
            var updatedClient = await repository.UpdateAsync(clientEntity);
            return new BaseResponse<ClientResponse>(true, "Cliente Atualizado Com Sucesso!", mapper.Map<ClientResponse>(updatedClient));
        }
    }
}