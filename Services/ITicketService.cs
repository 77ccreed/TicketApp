public interface ITicketService
{
  void CreateTicket(Ticket ticket);
  IEnumerable<Ticket> GetAllTickets();
  IEnumerable<Ticket> GetAllResolvedTickets();
}