using DigiLearn.Web.Infrastructure;
using DigiLearn.Web.Infrastructure.RazorUtils;
using TicketModule.Core.DTOs.Tickets;
using TicketModule.Core.Services;

namespace DigiLearn.Web.Pages.Profile.Ticket
{
    public class IndexModel : BaseRazorFilter<TicketFilterParams>
    {
        private ITicketService _ticketService;

        public IndexModel(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        public TicketFilterResult FilterResult { get; set; }
        public async Task OnGet()
        {
            FilterResult = await _ticketService.GetTicketsByFilter(new TicketFilterParams()
            {
                UserId = User.GetUserId(),
                Take = 10,
                PageId = FilterParams.PageId
            });
        }
    }
}
