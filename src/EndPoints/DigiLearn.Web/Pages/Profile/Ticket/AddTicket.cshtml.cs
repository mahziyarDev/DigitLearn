using DigiLearn.Web.Infrastructure;
using DigiLearn.Web.Infrastructure.RazorUtils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TicketModule.Core.DTOs.Tickets;
using TicketModule.Core.Services;
using UserModule.Core.Services;

namespace DigiLearn.Web.Pages.Profile.Ticket
{
    [BindProperties]
    [Authorize]
    public class AddTicketModel : BaseRazorToast
    {
        private readonly IUserFacade _userFacade;
        private readonly ITicketService _ticketService;
        public AddTicketModel(IUserFacade userFacade, ITicketService ticketService)
        {
            _userFacade = userFacade;
            _ticketService = ticketService;
        }

        [Display(Name = "عنوان پیام")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Title { get; set; }
        [Display(Name = "متن پیام")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Text { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var user = await _userFacade.GetUserByPhoneNumber(User.GetPhoneNumber());
            var fullName = user?.Name + " " + user?.Family;

            var command = new CreateTicketCommand(user.Id, fullName, user.PhoneNumber, Title, Text);
            var res = await _ticketService.CreateTicket(command);
            return RedirectAndShowAlert(res, RedirectToPage("/Profile/Ticket/Index"));
        }
    }
}
