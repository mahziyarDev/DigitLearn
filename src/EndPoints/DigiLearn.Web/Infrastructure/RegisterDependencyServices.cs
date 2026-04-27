//using Common.EventBus.Abstractions;
//using Common.EventBus.RabbitMQ;
using DigiLearn.Web.Infrastructure.JwtUtil;
using DigiLearn.Web.Infrastructure.RazorUtils;
using UserModule.Core;
//using DigiLearn.Web.Infrastructure.Services;

namespace DigiLearn.Web.Infrastructure;

public static class RegisterDependencyServices
{
    public static IServiceCollection RegisterWebDependencies(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddScoped<HttpClientAuthorizationDelegatingHandler>();
        services.AddTransient<IRenderViewToString, RenderViewToString>();
        
        //services.AddSingleton<IEventBus, EventBusRabbitMQ>();
        //services.AddAutoMapper(confing => confing.AddProfile<MapperProfile>());
        //services.AddScoped<IHomePageService, HomePageService>();

        return services;
    }
}