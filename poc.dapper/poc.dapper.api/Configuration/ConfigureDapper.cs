using Npgsql;
using System.Data;

namespace poc.dapper.api.Configuration;

public static class DapperConfig
{
    public static void AddDapperConfiguration(this IServiceCollection services, WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        services.AddSingleton<IDbConnection>(sp =>
            new NpgsqlConnection(connectionString));
    }
}