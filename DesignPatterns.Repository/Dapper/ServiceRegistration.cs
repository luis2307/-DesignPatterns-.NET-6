using DesignPatterns.Dapper;
using Microsoft.Extensions.DependencyInjection;

namespace DesignPatterns.Repository.Dapper
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {

            // AddTransient
            services.AddTransient<IPetRepository, PetRepository>();
            // AddScope 

            // AddSingleton
        }
    }
}
