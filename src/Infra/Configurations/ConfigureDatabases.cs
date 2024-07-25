

using Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Configurations;

public class ConfigureDatabases
{
    public static void ConfigureDependenciesDatabase(IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContext<ApplicationDbContext>(
            options => options.UseNpgsql(configuration.GetConnectionString("ClientData"))
        );
        serviceCollection.AddDbContext<ClientAuthDbContext>(
            options => options.UseNpgsql(configuration.GetConnectionString("ClientAuthConnection"))
        );
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
}