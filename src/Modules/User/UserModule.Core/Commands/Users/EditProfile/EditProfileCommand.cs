using Common.Application;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver.Linq;
using UserModule.Data;

namespace UserModule.Core.Commands.Users.EditProfile
{
    public class EditProfileCommand : IBaseCommand
    {
        public EditProfileCommand(string name, string family)
        {
            Name = name;
            Family = family;
        }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
    public class EditUserCommandHandler : IBaseCommandHandler<EditProfileCommand>
    {
        private readonly UserContext _userContext;

        public EditUserCommandHandler(UserContext userContext)
        {
            _userContext = userContext;
        }

        public async Task<OperationResult> Handle(EditProfileCommand request, CancellationToken cancellationToken)
        {
            var user = await _userContext.Users.FirstOrDefaultAsync(x => x.Id == request.UserId);
            if(user == null)
            {
                return OperationResult.NotFound();
            }
            user.Name = request.Name;
            user.Family = request.Family;
            if (!string.IsNullOrWhiteSpace(request.Email) && user?.Email?.ToLower() != request.Email?.ToLower())
            {
                if(await _userContext.Users.AnyAsync(x=>x.Email == request.Email))
            }
            await _userContext.SaveChangesAsync();
            return OperationResult.Success();

        }
    }

    public class EditUserCommandValidator : AbstractValidator<EditProfileCommand>
    {
        public EditUserCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().NotEmpty();

            RuleFor(x => x.Family)
                .NotNull().NotEmpty();

            
        }
    }
}
