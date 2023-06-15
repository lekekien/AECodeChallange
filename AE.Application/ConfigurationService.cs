using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace AE.Application
{
    public static class ConfigurationService
    {
        public static void AddMediatrApplication(this IServiceCollection services)
        {
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
