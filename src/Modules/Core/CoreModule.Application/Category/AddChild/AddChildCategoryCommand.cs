using Common.Application;
using CoreModule.Domain.CategoryAgg.DomainService;
using CoreModule.Domain.CategoryAgg.Repository;

namespace CoreModule.Application.Category.AddChild;

public record AddChildCategoryCommand(
    Guid ParentCategoryId ,
    string Title ,
    string Slug
    ):IBaseCommand;
    
public class AddChildCategoryCommandHandler : IBaseCommandHandler<AddChildCategoryCommand>
{
    private readonly ICategoryRepository _courseCategoryRepository;
    private readonly ICategoryDomainService _categoryDomainService;
    /// <summary></summary>
    /// <param name="categoryRepository"></param>
    /// <param name="categoryDomainService"></param>
    public AddChildCategoryCommandHandler(ICategoryRepository categoryRepository, ICategoryDomainService categoryDomainService)
    {
        _courseCategoryRepository = categoryRepository;
        _categoryDomainService = categoryDomainService;
    }

    public async Task<OperationResult> Handle(AddChildCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Domain.CategoryAgg.Models.Category(request.Title, request.Slug, request.ParentCategoryId, _categoryDomainService);

        await _courseCategoryRepository.AddAsync(category);
        await _courseCategoryRepository.Save();
        return OperationResult.Success();
    }
}