using System.ComponentModel.DataAnnotations;
using TicketModule.Data.Entities;

namespace TicketModule.Core.DTOs.Tickets;

public class CreateTicketCommand
{
    public CreateTicketCommand(Guid userId, string ownerFullName, string phoneNumber, string title, string text)
    {
        UserId = userId;
        OwnerFullName = ownerFullName;
        PhoneNumber = phoneNumber;
        Title = title;
        Text = text;
    }

    public Guid UserId { get; set; }
    public string OwnerFullName { get; set; }
    public string PhoneNumber { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
}