using Common.Application;
using UserModule.Core.Commands.Users.Register;
using MediatR;
using UserModule.Core.Queries._DTOs.User;
using UserModule.Core.Queries.Users.GetByPhoneNumber;

namespace UserModule.Core.Services
{
    public interface IUserFacade
    {
        Task<OperationResult<Guid>> RegisterUser(RegisterUserCommand command);
        //Task<UserDto?> GetUserById(Guid userId);
        Task<UserDto?> GetUserByPhoneNumber(string phoneNumber);
    }

    public class UserFacade : IUserFacade
    {
        private readonly IMediator _mediator;

        public UserFacade(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<OperationResult<Guid>> RegisterUser(RegisterUserCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<UserDto?> GetUserByPhoneNumber(string phoneNumber)
        {
            var query = new GetUserByPhoneNumberQuery(phoneNumber);
            return await _mediator.Send(query);
        }

    }
}
