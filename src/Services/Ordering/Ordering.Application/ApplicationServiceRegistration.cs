using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Application.Behaviours;

namespace Ordering.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices( this IServiceCollection services )
        {
            var asm = Assembly.GetExecutingAssembly();

            services.AddAutoMapper( asm );
            services.AddValidatorsFromAssembly( asm );
            services.AddMediatR( asm );

            services.AddTransient( typeof( IPipelineBehavior<,> ), typeof( UnhandledExceptionBehaviour<,> ) );
            services.AddTransient( typeof( IPipelineBehavior<,> ), typeof( ValidationBehaviour<,> ) );

            return services;
        }
    }
}
