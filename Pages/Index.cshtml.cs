using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TicketApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ITicketService _ticketService;

        public List<Ticket> Tickets { get; private set; } = new List<Ticket>();
        public int Id { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ITicketService ticketService)
        {
            _logger = logger;
            _ticketService = ticketService;
        }

        public void OnGet()
        {
            Tickets = _ticketService.GetAllTickets()
                        .Where(t => !t.Resolved)
                        .OrderByDescending(t => t.ResolutionDeadline)
                        .ToList();
            _logger.LogInformation($"Retrieved {Tickets.Count} unresolved tickets.");
        }

        public IActionResult OnPostResolve(int id)
        {
            var allTickets = _ticketService.GetAllTickets();
            var ticket = allTickets.FirstOrDefault(t => t.Id == id);
            if (ticket != null)
            {
                ticket.Resolve();
                // No need to update the ticket in the dictionary because it's the same instance
            }
            else
            {
                _logger.LogWarning("Attempted to resolve a ticket that does not exist: ID {TicketId}", id);
                return NotFound(); // Redirect to a Not Found page or indicate the error
            }

            return RedirectToPage();
        }
    }
}
