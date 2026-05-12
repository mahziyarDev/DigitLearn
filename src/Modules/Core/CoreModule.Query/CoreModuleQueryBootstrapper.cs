using System.Reflection;
using CoreModule.Query._Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoreModule.Query;

public class CoreModuleQueryBootstrapper
{
    public static void RegisterDependency(IServiceCollection services, IConfiguration configuration)
    {
        
        var assembly = Assembly.GetExecutingAssembly();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
        
        services.AddDbContext<QueryContext>(option =>
        {
            option.UseSqlServer(configuration.GetConnectionString("CoreModule_Context"));
        });
    }
}