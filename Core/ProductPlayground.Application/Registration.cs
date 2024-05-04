using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ProductPlayground.Application.Bases;
using ProductPlayground.Application.Beheviors;
using ProductPlayground.Application.Exptions;
using ProductPlayground.Application.Features.Products.Rules;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProductPlayground.Application
{
    public static class Registration
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddTransient<ExceptionMiddleware>();
            services.AddRulesFromAssemblyContaining(assembly, typeof(BaseRules));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
            services.AddValidatorsFromAssembly(assembly);

            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("en");
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehavior<,>));
        }

        private static IServiceCollection AddRulesFromAssemblyContaining(this IServiceCollection services, Assembly assembly, Type type)
        {
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && t != type).ToList();
            foreach (var item in types)
            {
                services.AddTransient(item);
            }
            return services;
        }
    }
}
