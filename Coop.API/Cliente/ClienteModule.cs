using Coop.Domain.Cliente.Repository;
using Coop.Domain.Cliente.UnitOfWork;
using Coop.Infrastructure.Cliente.Respository;
using Coop.Infrastructure.Cliente.UnitOfWork;

namespace Coop.API.Cliente
{
    public static class ClienteModule
    {
        public static IServiceCollection ClienteServices(this IServiceCollection services)
        {
            services.AddScoped<IPersonaRepository, PersonaRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ICrearClienteUnitOfWork, CrearClienteUnitOfWork>();
            return services;
        }
    }
}
