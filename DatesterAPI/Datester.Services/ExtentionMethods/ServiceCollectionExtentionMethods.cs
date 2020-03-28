using Datester.Services.Interfaces.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Datester.Services.ExtentionMethods
{
    public static class ServiceCollectionExtentionMethods
    {
        public static IServiceCollection MapConventionalDependencies(this IServiceCollection services)
        {
            var serviceTypes = typeof(IService);
            var scopedTypes = typeof(IScopedService);
            var singletonTypes = typeof(ISingletonService);



            return services;
        }
    }
}
