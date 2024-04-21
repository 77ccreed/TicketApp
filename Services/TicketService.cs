using System.Collections.Concurrent;
public class TicketService : ITicketService
{
  private ConcurrentDictionary<int, Ticket> Tickets = new ConcurrentDictionary<int, Ticket>();
  private int NextTicketId = 1;

  public void CreateTicket(Ticket ticket)
  {
    ticket.Id = Interlocked.Increment(ref NextTicketId);
    ticket.SubmissionTime = DateTime.Now;
    ticket.Resolved = false; // Ensure the ticket is not resolved when it's created
    Tickets.TryAdd(ticket.Id, ticket);
  }

  public IEnumerable<Ticket> GetAllTickets()
  {
    return Tickets.Values;
  }

  public IEnumerable<Ticket> GetAllResolvedTickets()
  {
    return Tickets.Values.Where(t => t.Resolved);
  }
}