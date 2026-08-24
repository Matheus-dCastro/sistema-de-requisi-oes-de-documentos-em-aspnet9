using Aplication.Interfaces;
using Aplication.Service;
using Domain.Interface;
using infrastruruty.Data;
using infrastruruty.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;   
using Domain.Interface.IDocumentrepository;
           

namespace infrastruruty
{
    public static class DependicyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(Options =>
            {
                Options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));
            });
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IDocumentrepository, DocumentRepository>();
            return services;
        }
    }
}