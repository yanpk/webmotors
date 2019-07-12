using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using WebMotors.Repository;
using WebMotors.Interface;
using WebMotors.Application.Configuration;
using WebMotors.Application;
using WebMotors.AspNetContext;
using WebMotors.Repository.Context;

namespace WebMotors.Infra.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static IConfiguration Configuration { get; }
        public static IServiceCollection AddUnitOfWork(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<PortalContext, PortalContext>();
            serviceCollection.AddSingleton<AutoMapperConfiguration>();
            return serviceCollection;
        }

        public static IServiceCollection AddRealStateApplication(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<AnuncioWebMotorsApp>();
            serviceCollection.AddScoped<IAnuncioWebMotorsRepository, AnuncioWebMotorsRepository>();
            return serviceCollection;
        }

        public static IServiceCollection AddCustomIdentity(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddCustomIdentityModule();
            return serviceCollection;
        }

        public static IServiceCollection AddIConfiguration(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton(provider => Configuration);

            return serviceCollection;
        }
    }
}
