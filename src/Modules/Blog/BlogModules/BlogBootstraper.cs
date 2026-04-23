using BlogModules.Context;
using BlogModules.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace BlogModules
{
    public static class BlogBootstraper
    {
        public static IServiceCollection InitBlogModule(this IServiceCollection services,IConfiguration config)
        {
            services.AddDbContext<BlogContext>(option =>
            {
                option.UseSqlServer(config.GetConnectionString("Blog_Context"));
            });


            //---Repository
            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();

            //-----service
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IPostRepository, PostRepository>();

            return services;
        }
    }
}
