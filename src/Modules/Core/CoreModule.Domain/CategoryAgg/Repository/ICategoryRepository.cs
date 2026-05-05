using Common.Domain.Repository;
using CoreModule.Domain.CategoryAgg.Models;

namespace CoreModule.Domain.CategoryAgg.Repository
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task Delete(Category category);
    }
}
