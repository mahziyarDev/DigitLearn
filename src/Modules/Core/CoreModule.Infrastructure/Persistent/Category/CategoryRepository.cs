using Common.Infrastructure.Repository;
using CoreModule.Domain.CategoryAgg.Repository;
using Microsoft.EntityFrameworkCore;

namespace CoreModule.Infrastructure.Persistent.Category;

public class CategoryRepository : BaseRepository<Domain.CategoryAgg.Models.Category, CoreModuleEfContext>, ICategoryRepository
{
    /// <summary></summary>
    /// <param name="context"></param>
    public CategoryRepository(CoreModuleEfContext context) : base(context)
    {
    }

    public async Task Delete(Domain.CategoryAgg.Models.Category category)
    {
        var categoryHasCourse = await Context.Courses
            .AnyAsync(f => f.CategoryId == category.Id || f.SubCategoryId == category.Id);

        if (categoryHasCourse)
        {
            throw new Exception("این دسته بندی دارای چندین دوره است");
        }

        var children = await Context.Categories.Where(r => r.ParentId == category.Id).ToListAsync();
        if (children.Any())
        {
            foreach (var child in children)
            {
                var isAnyCourse = await Context.Courses
                    .AnyAsync(f => f.CategoryId == category.Id || f.SubCategoryId == category.Id);
                if (isAnyCourse)
                {
                    throw new Exception("این دسته بندی دارای چندین دوره است");
                }
                else
                {
                    Context.Remove(child);
                }
            }
        }
        Context.Remove(category);
        await Context.SaveChangesAsync();
    }
}