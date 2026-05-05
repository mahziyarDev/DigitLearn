using FluentValidation;

namespace CoreModule.Application.Category.Edit;

public class EditCategoryCommandValidator : AbstractValidator<EditCategoryCommand>
{
    public EditCategoryCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .NotNull();
        RuleFor(x => x.Slug)
            .NotEmpty()
            .NotNull();
    }
}