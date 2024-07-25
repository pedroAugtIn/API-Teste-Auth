using AutoMapper;
using Domain.DTOs.Entries;
using Domain.DTOs.Responses;
using Domain.Models;

namespace Domain.AutoMapper
{
    public class ConfigurationMapping : Profile
    {
        public ConfigurationMapping()
        {
            CreateMap<ClientEntity, ClientResponse>();
            CreateMap<ClientEntry, ClientEntity>();
        }        
    }
}