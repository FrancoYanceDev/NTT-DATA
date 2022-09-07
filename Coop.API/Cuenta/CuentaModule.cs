using Coop.Domain.Cuenta.Repository;
using Coop.Domain.Cuenta.UnitOfWork;
using Coop.Infrastructure.Cuenta;
using Coop.Infrastructure.Cuenta.Repository;
using Coop.Infrastructure.Cuenta.UnitOfWork;

namespace Coop.API.Cuenta
{
    public static class CuentaModule
    {
        public static IServiceCollection CuentaServices(this IServiceCollection services)
        {
            services.AddScoped<ICuentaRepository, CuentaRepository>();
            services.AddScoped<ICuentaUnitOfWork, CuentaUnitOfWork>();
            return services;
        }
    }
}
