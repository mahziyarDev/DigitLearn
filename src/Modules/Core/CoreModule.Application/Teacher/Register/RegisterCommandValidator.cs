using FluentValidation;

namespace CoreModule.Application.Teacher.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterTeacherCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.UserName)
            .NotNull().NotEmpty();
        RuleFor(x => x.CvFile)
            .NotNull().NotEmpty();
           
    }
}