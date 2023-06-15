using AE.Application.Repository;
using AE.Data;
using System;

namespace AECodeChallange
{
    public static class DependencyRegister
    {
        public static void AddDIRegister(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
