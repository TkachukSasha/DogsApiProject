using Dogs.Application.Common.Contracts;
using Dogs.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dogs.Infrastructure.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<DogsDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<IDogsDbContext>(provider =>
                provider.GetService<DogsDbContext>());
            return services;
        }
    }
}
