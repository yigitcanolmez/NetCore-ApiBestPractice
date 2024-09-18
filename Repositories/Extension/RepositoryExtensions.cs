using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Repositories.Extension;

public static class RepositoryExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddDbContext<AppDbContext>(options =>
        {
            var connectionStringOption = configuration.GetSection(ConnectionStringOption.Key)
                                                              .Get<ConnectionStringOption>();

            options.UseSqlServer(connectionStringOption!.SqlServer,
                sqlServerOptionsAction =>
                {
                    sqlServerOptionsAction.MigrationsAssembly(typeof(RepositoryAssembly).Assembly.FullName);
                });
        });

    }
}
