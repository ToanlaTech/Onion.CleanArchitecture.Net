using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Onion.CleanArchitecture.Net.Application.Behaviours;
using System.Reflection;

namespace Onion.CleanArchitecture.Net.Application
{
    public static class ServiceExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        }
    }
}
