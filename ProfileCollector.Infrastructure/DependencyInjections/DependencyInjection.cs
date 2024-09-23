using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProfileCollector.Application.Interfaces.Repositories;
using ProfileCollector.Infrastructure.Persistence;
using ProfileCollector.Infrastructure.Repositories;
using Raven.Client.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileCollector.Infrastructure.DependencyInjections
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(provider =>
            {
                var databaseUrl = configuration["RavenDatabase:Url"];
                var databaseName = configuration["RavenDatabase:Name"];
                return new AppDatabaseStore(databaseUrl, databaseName);
            });

            services.AddSingleton(provider => provider.GetRequiredService<AppDatabaseStore>().Store);

            services.AddScoped(provider =>
            {
                var store = provider.GetRequiredService<IDocumentStore>();
                return store.OpenAsyncSession();
            });

            services.AddTransient<IUserRepository, UserRepository>();

            return services;
        }
    }
}
