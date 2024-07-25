using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infra.Context
{
     public class ClientAuthDbContextFactory : IDesignTimeDbContextFactory<ClientAuthDbContext>
    {
        public ClientAuthDbContext CreateDbContext(string[] args)
        {
            var ambiente = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var file = Path.Combine("..", "Api", $"appsettings.{ambiente}.json");

            var jsonString = File.ReadAllText(file);
            var json = JsonSerializer.Deserialize<JsonNode>(jsonString);
            string connectionString = (string)json!["ConnectionStrings"]!["ClientAuthConnection"]!;
            var optionsBuilder = new DbContextOptionsBuilder<ClientAuthDbContext>();

            optionsBuilder.UseNpgsql(connectionString);
            return new ClientAuthDbContext(optionsBuilder.Options);
        }
    }
}