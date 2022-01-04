using AutoMapper;
using MediatR;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace DbToJSON.Infrastructure
{
    public static class InfraServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //services.AddMed
            return services;
        }
        
    }
}
