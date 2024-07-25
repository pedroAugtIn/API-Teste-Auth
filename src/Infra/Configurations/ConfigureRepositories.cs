using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces;
using Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Configurations
{
    public class ConfigureRepositories
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        }
    }
}