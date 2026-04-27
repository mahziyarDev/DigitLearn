using Common.Application.SecurityUtil;
using DigiLearn.Web.Infrastructure.JwtUtil;
using DigiLearn.Web.Infrastructure.RazorUtils;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using UserModule.Core.Services;

namespace DigiLearn.Web.Pages.Auth
{
    [BindProperties]
    public class LoginModel : BaseRazorToast
    {
        private readonly IUserFacade _userFacade;
        private readonly IConfiguration _configuration;

        public LoginModel(IUserFacade userFacade, IConfiguration configuration)
        {
            _userFacade = userFacade;
            _configuration = configuration;
        }

        [Display(Name = "شماره تلفن")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string PhoneNumber { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MinLength(5, ErrorMessage = "کلمه عبور باید بیشتر از 5 کاراکتر باشد")]
        public string Password { get; set; }

        public bool IsRememberMe { get; set; }

        public IActionResult OnGet()
        {

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToPage("/Index");
            }

            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            var user = await _userFacade.GetUserByPhoneNumber(PhoneNumber);
            if (user == null)
            {
                ErrorAlert();
                return Page();
            }
            if (Sha256Hasher.IsCompare(user.Password, Password) == false)
            {
                ErrorAlert("اطلاعات وارد شده نادرست می باشد");
                return Page();
            }
            var token = JwtTokenBuilder.BuildToken(user, _configuration);
          
            if (IsRememberMe)
            {
                HttpContext.Response.Cookies.Append("digi-token", token, new CookieOptions()
                {
                    HttpOnly = true,
                    Expires = DateTimeOffset.Now.AddDays(3),
                    Secure = true
                });
            }
            else
            {
                HttpContext.Response.Cookies.Append("digi-token", token, new CookieOptions()
                {
                    HttpOnly = true,                   
                    Secure = true
                });
            }
            SuccessAlert("ورود موفقیت آمیز بود.");
            return RedirectToPage("../Index");
        }

    }
}
