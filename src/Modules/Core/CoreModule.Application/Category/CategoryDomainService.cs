using Common.Domain.Utils;
using CoreModule.Domain.CategoryAgg.DomainService;
using CoreModule.Domain.CategoryAgg.Repository;

namespace CoreModule.Application.Category;

public class CategoryDomainService : ICategoryDomainService
{
    private readonly ICategoryRepository _repository;

    public CategoryDomainService(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public bool SlugIsExist(string slug)
    {
        return _repository.Exists(f => f.Slug == slug.ToSlug());
    }
    public bool TitleIsExist(string title)
    {
        return _repository.Exists(f => f.Title == title);
    }
}