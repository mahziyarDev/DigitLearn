using Common.Application;
using CoreModule.Application.Category.AddChild;
using CoreModule.Application.Category.Create;
using CoreModule.Application.Category.Edit;
using CoreModule.Query.Category._DTOs;

namespace CoreModule.Facade.Category;

public interface ICategoryFacade
{
    Task<OperationResult> Create(CreateCategoryCommand command);
    Task<OperationResult> Edit(EditCategoryCommand command);
    Task<OperationResult> Delete(Guid id);
    Task<OperationResult> AddChild(AddChildCategoryCommand command);



    Task<List<CourseCategoryDto>> GetMainCategories();
    Task<CourseCategoryDto?> GetById(Guid categoryId);
    Task<List<CourseCategoryDto>> GetChildren(Guid parentId);
}