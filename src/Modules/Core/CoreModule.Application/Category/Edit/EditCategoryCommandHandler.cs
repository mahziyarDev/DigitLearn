using Common.Application;
using CoreModule.Domain.CategoryAgg.DomainService;
using CoreModule.Domain.CategoryAgg.Repository;

namespace CoreModule.Application.Category.Edit;

public class EditCategoryCommandHandler : IBaseCommandHandler<EditCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly ICategoryDomainService _categoryDomainService;
    /// <summary></summary>
    /// <param name="categoryRepository"></param>
    /// <param name="categoryDomainService"></param>
    public EditCategoryCommandHandler(ICategoryRepository categoryRepository, ICategoryDomainService categoryDomainService)
    {
        _categoryRepository = categoryRepository;
        _categoryDomainService = categoryDomainService;
    }

    public async Task<OperationResult> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetTracking(request.CategoryId);
        if (category == null)
        {
            return OperationResult.NotFound("category not found");
        }
        category.Edit(request.Title,request.Slug,_categoryDomainService);
        _categoryRepository.Update(category);
        await _categoryRepository.Save();
        return OperationResult.Success();
    }
}