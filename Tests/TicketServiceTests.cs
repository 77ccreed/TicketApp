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
    // Arrange
    var ticket = new Ticket { Description = "Test ticket" };

    // Act
    _ticketService.CreateTicket(ticket);
    var tickets = _ticketService.GetAllTickets().ToList();

    // Assert
    Assert.Contains(ticket, tickets);
    Assert.Single(tickets);  // Verifies that the ticket was added correctly and only one exists
  }

  [Fact]
  public void CreateTicket_ShouldAddDuplicateTicket()
  {
    // Arrange
    var ticket1 = new Ticket { Description = "Test ticket" };
    var ticket2 = new Ticket { Description = "Test ticket" };
    _ticketService.CreateTicket(ticket1);

    // Act
    _ticketService.CreateTicket(ticket2);
    var tickets = _ticketService.GetAllTickets().ToList();

    // Assert
    Assert.Equal(2, tickets.Count);  // Verifies that the duplicate ticket was added
  }

  [Fact]
  public void GetAllTickets_ShouldReturnAllTickets()
  {
    // Arrange
    _ticketService = new TicketService();  // Reset the service to ensure no tickets exist
    var ticket1 = new Ticket { Description = "Resolved ticket", Resolved = true };
    var ticket2 = new Ticket { Description = "Unresolved ticket", Resolved = false };
    _ticketService.CreateTicket(ticket1);
    _ticketService.CreateTicket(ticket2);

    // Act
    var allTickets = _ticketService.GetAllTickets().ToList();

    // Assert
    Assert.Equal(2, allTickets.Count());
    Assert.Contains(ticket1, allTickets);
    Assert.Contains(ticket2, allTickets);
  }

  [Fact]
  public void GetAllTickets_ShouldReturnEmptyListWhenNoTicketsExist()
  {
    // Arrange
    _ticketService = new TicketService();  // Reset the service to ensure no tickets exist

    // Act
    var allTickets = _ticketService.GetAllTickets().ToList();

    // Assert
    Assert.Empty(allTickets);  // Verifies that an empty list is returned when no tickets exist
  }


}