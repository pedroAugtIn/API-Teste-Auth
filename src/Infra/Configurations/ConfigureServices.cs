using Domain.AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Services.Services;

namespace Infra.Configurations
{
    public class ConfigureServices
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(typeof(ConfigurationMapping));
            serviceCollection.AddScoped<IClientService, ClientService>();
            serviceCollection.AddScoped<ITokenRepository, TokenRepository>();
        }
    }
}