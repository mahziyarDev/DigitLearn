using DigiLearn.Web.Infrastructure;
using DigiLearn.Web.Infrastructure.RazorUtils;
using UserModule.Core.Queries._DTOs.User;
using UserModule.Core.Services;

namespace DigiLearn.Web.Pages.Profile
{
    public class IndexModel : BaseRazorToast
    {
        private readonly IUserFacade _userFacade;

        public IndexModel(IUserFacade userFacade)
        {
            _userFacade = userFacade;
        }

        public UserDto UserDto { get; set; }
        public async Task OnGet()
        {
            UserDto = await _userFacade.GetUserByPhoneNumber(User.GetPhoneNumber());
        }
    }
}
