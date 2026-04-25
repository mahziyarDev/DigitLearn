using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using System.Reflection;
using UserModule.Core.Services;
using UserModule.Data;

namespace UserModule.Core
{
    public static class UserModuleBootStrapper
    {
        public static IServiceCollection InitUserModule(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<UserContext>(option =>
            {

                option.UseSqlServer(config.GetConnectionString("user_context"));
            });
            var assembly = Assembly.GetExecutingAssembly();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
            
            services.AddValidatorsFromAssembly(assembly);

            services.AddAutoMapper(conf => conf.AddProfile<MapperProfile>());

            services.AddScoped<IUserFacade, UserFacade>();
            return services;
        }
    }
}
