using BlogModules.Context;
using BlogModules.Repository;
using BlogModules.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace BlogModules
{
    public static class BlogBootstraper
    {
        public static IServiceCollection InitBlogModule(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<BlogContext>(option =>
            {
                option.UseSqlServer(config.GetConnectionString("Blog_Context"));
            });
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IPostRepository, PostRepository>();

            services.AddScoped<IBlogService, BlogService>();

            services.AddAutoMapper(conf => conf.AddProfile<MapperProfile>());
            return services;
        }
    }
}
