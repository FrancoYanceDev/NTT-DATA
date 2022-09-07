using Coop.API.Base.Services;
using Coop.Domain.Base.Services;
using Coop.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Coop.API.Base
{
    public static class BaseModule
    {
        public static readonly string CorsPolicy = "CorsPolicy";
        public static WebApplicationBuilder BaseBuilder(this WebApplicationBuilder builder)
        {
            /*Base de datos:  conexión*/
            builder.Services.AddDbContext<CoopContext>(
                options => options.UseSqlServer(
                    "name=ConnectionStrings:DefaultConnection"
                    , b => b.MigrationsAssembly("Coop.Infrastructure")));


            builder.Services.AddCors(
                options => options.AddPolicy(
                                CorsPolicy
                                , builder => builder
                                                    .AllowAnyOrigin()
                                                    .AllowAnyMethod()
                                                    .AllowAnyHeader()
                            ));
            return builder;
        }

        public static IServiceCollection BaseServices(this IServiceCollection services)
        {
            services.AddScoped<IDateValidatorService, DateValidatorDDMMYYYYService>(); 
            return services;
        }
    }
}
