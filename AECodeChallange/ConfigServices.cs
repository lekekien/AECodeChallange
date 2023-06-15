using AE.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AECodeChallange
{
    public static class ConfigServices
    {
        public static void AddConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddDbContext<AECCodeChallangeContext>(options => options.UseNpgsql(configuration.GetConnectionString("AppConnection")));
        }
    }
}
