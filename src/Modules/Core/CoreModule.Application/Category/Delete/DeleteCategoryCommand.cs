using Common.Application;
using CoreModule.Domain.CategoryAgg.DomainService;
using CoreModule.Domain.CategoryAgg.Repository;

namespace CoreModule.Application.Category.Delete;

public record DeleteCategoryCommand (Guid CategoryId): IBaseCommand;

public class DeleteCategoryCommandHandler : IBaseCommandHandler<DeleteCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly ICategoryDomainService _categoryDomainService;
    /// <summary></summary>
    /// <param name="categoryRepository"></param>
    /// <param name="categoryDomainService"></param>
    public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, ICategoryDomainService categoryDomainService)
    {
        _categoryRepository = categoryRepository;
        _categoryDomainService = categoryDomainService;
    }

    public async Task<OperationResult> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetTracking(request.CategoryId);
        if (category == null)
        {
            return OperationResult.NotFound("category not found");
        }

        await _categoryRepository.Delete(category);
        await _categoryRepository.Save();
        return OperationResult.Success();
    }
}
