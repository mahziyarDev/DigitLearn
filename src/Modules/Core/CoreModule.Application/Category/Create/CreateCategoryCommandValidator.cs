using FluentValidation;

namespace CoreModule.Application.Category.Create;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .NotNull();
        RuleFor(x => x.Slug)
            .NotEmpty()
            .NotNull();
    }    
}