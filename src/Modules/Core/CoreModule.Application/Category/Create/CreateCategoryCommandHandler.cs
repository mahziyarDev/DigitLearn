using Common.Application;
using CoreModule.Domain.CategoryAgg.DomainService;
using CoreModule.Domain.CategoryAgg.Repository;

namespace CoreModule.Application.Category.Create;

public class CreateCategoryCommandHandler : IBaseCommandHandler<CreateCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly ICategoryDomainService _categoryDomainService;

    /// <summary></summary>
    /// <param name="categoryRepository"></param>
    /// <param name="categoryDomainService"></param>
    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, ICategoryDomainService categoryDomainService)
    {
        _categoryRepository = categoryRepository;
        _categoryDomainService = categoryDomainService;
    }

    public async Task<OperationResult> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Domain.CategoryAgg.Models.Category(request.Title, request.Slug, null, _categoryDomainService);
        
        await _categoryRepository.AddAsync(category);
        await _categoryRepository.Save();
        return OperationResult.Success();
    }
}