using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Networm.Infrastructure.Persistence;
using Networm.Infrastructure.Seeders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Networm.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NetwormBookDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("Networm")));

            services.AddScoped<NetwormSeeder>();
        }
    }
}
