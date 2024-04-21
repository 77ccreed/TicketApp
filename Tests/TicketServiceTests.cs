using Xunit;
using System.Collections.Concurrent;
using System.Linq;

public class TicketServiceTests
{
  private TicketService _ticketService;

  public TicketServiceTests()
  {
    _ticketService = new TicketService();
  }

  [Fact]
  public void CreateTicket_ShouldAddTicketToTicketsDictionary()
  {
    var ticket = new Ticket { Description = "Test ticket" };

    _ticketService.CreateTicket(ticket);
    var tickets = _ticketService.GetAllTickets().ToList();

    Assert.Contains(ticket, tickets);
    Assert.Single(tickets);  // Verifies that the ticket was added correctly and only one exists
  }

  [Fact]
  public void GetAllTickets_ShouldReturnAllTickets()
  {
    var ticket1 = new Ticket { Description = "Resolved ticket", Resolved = true };
    var ticket2 = new Ticket { Description = "Unresolved ticket", Resolved = false };
    _ticketService.CreateTicket(ticket1);
    _ticketService.CreateTicket(ticket2);

    var allTickets = _ticketService.GetAllTickets().ToList();

    Assert.Equal(2, allTickets.Count());
    Assert.Contains(ticket1, allTickets);
    Assert.Contains(ticket2, allTickets);
  }

}
