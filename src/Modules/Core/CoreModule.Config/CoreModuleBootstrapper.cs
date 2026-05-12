using System.Reflection;
using CoreModule.Application.Category;
using CoreModule.Application.Category.Create;
using CoreModule.Application.Course;
using CoreModule.Application.Teacher;
using CoreModule.Domain.CategoryAgg.DomainService;
using CoreModule.Domain.CourseAgg.DomainService;
using CoreModule.Domain.TeacherAgg.DomainService;
using CoreModule.Facade;
using CoreModule.Infrastructure;
using CoreModule.Query;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoreModule.Config
{
    public static class CoreModuleBootstrapper
    {
        public static IServiceCollection InitCoreModule(this IServiceCollection services, IConfiguration configuration)
        {
            CoreModuleFacadeBootstrapper.RegisterDependency(services);
            CoreModuleInfrastructureBootstrapper.RegisterDependency(services, configuration);
            CoreModuleQueryBootstrapper.RegisterDependency(services, configuration);

            var assembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
            services.AddValidatorsFromAssembly(assembly);

            // services.AddValidatorsFromAssembly(typeof(CreateCategoryCommand).Assembly);

             services.AddScoped<ICourseDomainService, CourseDomainService>();
             services.AddScoped<ITeacherDomainService, TeacherDomainService>();
             services.AddScoped<ICategoryDomainService, CategoryDomainService>();
            // services.AddScoped<IOrderDomainService, OrderDomainService>();

            return services;
        }
    }
}