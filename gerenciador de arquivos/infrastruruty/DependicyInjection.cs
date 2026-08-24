using Aplication.Services;                                                                                                                             
using Domain.Interface;                                                                                                                                
using infrastruruty.Data;                                                                                                                              
using infrastruruty.Repositories;                                                                                                                      
using Microsoft.EntityFrameworkCore;                                                                                                                   
using Microsoft.Extensions.Configuration;                                                                                                              
using Microsoft.Extensions.DependencyInjection;    
           

namespace infrastruruty
{
    public static class DependicyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UserDB>(Options =>
            {
                Options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(UserDB).Assembly.FullName));
            });
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}