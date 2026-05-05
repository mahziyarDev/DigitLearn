using Common.Application;

namespace CoreModule.Application.Category.Edit;

public record EditCategoryCommand(
    Guid CategoryId,
    string Title,
    string Slug
): IBaseCommand;