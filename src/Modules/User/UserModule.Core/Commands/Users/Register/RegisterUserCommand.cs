using Common.Application;
using Common.Application.SecurityUtil;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using UserModule.Data;
using UserModule.Data.Entities.Users;

namespace UserModule.Core.Commands.Users.Register
{
    public class RegisterUserCommand : IBaseCommand<Guid>
    {
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
    public class RegisterUserCommandHandler : IBaseCommandHandler<RegisterUserCommand, Guid>
    {
        private readonly UserContext _userContext;

        public RegisterUserCommandHandler(UserContext userContext)
        {
            _userContext = userContext;
        }

        public async Task<OperationResult<Guid>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            if(await _userContext.Users.AnyAsync(x => x.PhoneNumber == request.PhoneNumber, cancellationToken))
            {
                return OperationResult<Guid>.Error("شماره تلفن تکراری است");
            }
            var user = new User
            {
                PhoneNumber = request.PhoneNumber,
                Password = Sha256Hasher.Hash(request.Password),
                Avatar = "default.png",
                Id = Guid.NewGuid()
            };
            await _userContext.AddAsync(user, cancellationToken);
            await _userContext.SaveChangesAsync(cancellationToken);

            return OperationResult<Guid>.Success(user.Id);
        }
    }
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull()
                .MinimumLength(6);
        }
    }
}
