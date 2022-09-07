using Coop.Domain.Movimiento.Domain;
using Coop.Domain.Movimiento.Reports;
using Coop.Domain.Movimiento.Repository;
using Coop.Domain.Movimiento.UnitOfWork;
using Coop.Infrastructure.Movimiento.Reports;
using Coop.Infrastructure.Movimiento.Repository;
using Coop.Infrastructure.Movimiento.UnitOfWork;

namespace Coop.API.Movimiento
{
    public static class MovimientoModule
    {
        public static IServiceCollection MovimientoServices(this IServiceCollection services)
        {
            services.AddScoped<IMovimientoRepository, MovimientoRepository>();
            services.AddScoped<IMovimientoUnitOfWork, MovimientoUnitOfWork>();
            services.AddScoped<IMovimientoStrategy, CuentaPersonalStrategy>();
            services.AddScoped<IMovimientoReporteGenerator, MovimientoReporteClienteGenerator>();
            


            return services;
        }
    }
}
