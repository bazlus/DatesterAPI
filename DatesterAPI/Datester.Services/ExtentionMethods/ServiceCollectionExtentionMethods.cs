using Datester.Services.Interfaces.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace Datester.Services.ExtentionMethods
{
    public static class ServiceCollectionExtentionMethods
    {
        public static IServiceCollection MapConventionalDependencies(this IServiceCollection services)
        {
            var serviceType = typeof(IService);
            var scopedType = typeof(IScopedService);
            var singletonType = typeof(ISingletonService);

            var types = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract)
                .Select(t => new
                {
                    Service = t.GetInterface($"I{t.Name}"),
                    Implementation = t
                })
                .Where(t => t.Service != null);

            foreach (var type in types)
            {
                if (serviceType.IsAssignableFrom(type.Service))
                {
                    services.AddTransient(type.Service, type.Implementation);
                }
                else if (scopedType.IsAssignableFrom(type.Service))
                {
                    services.AddScoped(type.Service, type.Implementation);
                }
                else if (singletonType.IsAssignableFrom(type.Service))
                {
                    services.AddSingleton(type.Service, type.Implementation);
                }
            }

            return services;
        }
    }
}
