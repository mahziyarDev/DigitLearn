using Common.Application;

namespace CoreModule.Application.Category.Create;

public record CreateCategoryCommand(
    string Title,
    string Slug,
    Guid ParentId
    ): IBaseCommand;