using DigiLearn.Web.Infrastructure;
using DigiLearn.Web.Infrastructure.RazorUtils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using UserModule.Core.Commands.Users.EditProfile;
using UserModule.Core.Services;
namespace DigiLearn.Web.Pages.Profile
{
    [BindProperties]
    public class EditProfileModel : BaseRazorToast
    {
        private readonly IUserFacade _userFacade;

        public EditProfileModel(IUserFacade userFacade)
        {
            _userFacade = userFacade;
        }

        public Guid UserId { get; set; }
        [Display(Name = "نام")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Name { get; set; }
        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Family { get; set; }
        [Display(Name = "ایمیل")]
        public string? Email { get; set; }
        [Display(Name = "رمز عبور")]
        public string? Password { get; set; }
        public async Task OnGet()
        {
            var user = await _userFacade.GetUserByPhoneNumber(User.GetPhoneNumber());
            if (user != null)
            {
                UserId = user.Id;
                Name = user.Name;
                Family = user.Family;
                Email = user.Email;

            }
        }
        public async Task<IActionResult> OnPost()
        {
            var res = await _userFacade.EditProfile(new EditProfileCommand(UserId, Name, Family, Email, Password));
            return RedirectAndShowAlert(res, RedirectToPage("/Profile/Index"));
        }


    }
}
