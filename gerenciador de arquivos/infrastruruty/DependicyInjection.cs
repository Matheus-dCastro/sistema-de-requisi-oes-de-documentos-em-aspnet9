using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Aplication.Services;
using Domain.Interface;
using infrastruruty.Data;
using infrastruruty.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace infrastruruty
{
    public static class DependicyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UserDB>(Options =>
            {
                Options.UseNpgsql(configuration.GetConnectionString("DefaltConection"),
                b => b.MigrationsAssembly(typeof(UserDB).Assembly.FullName));
            });
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}