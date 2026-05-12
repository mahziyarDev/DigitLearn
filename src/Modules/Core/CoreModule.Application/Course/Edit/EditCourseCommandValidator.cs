using FluentValidation;

namespace CoreModule.Application.Course.Edit;

public class EditCourseCommandValidator : AbstractValidator<EditCourseCommand>
{
    public EditCourseCommandValidator()
    {
        RuleFor(r => r.Title)
            .NotNull()
            .NotEmpty();

        RuleFor(r => r.Slug)
            .NotNull()
            .NotEmpty();


        RuleFor(r => r.Description)
            .NotNull()
            .NotEmpty();


        RuleFor(r => r.ImageFile)
            .NotNull();
    }
}