using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TicketApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public List<Ticket> Tickets { get; private set; } = new List<Ticket>();
        public int Id { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            Tickets = CreateTicketModel.Tickets.Values
                        .Where(t => !t.Resolved)
                        .OrderByDescending(t => t.ResolutionDeadline)
                        .ToList();
        }

        public IActionResult OnPostResolve(int id)
        {
            if (CreateTicketModel.Tickets.TryGetValue(id, out Ticket? ticket) && ticket != null) // Mark 'ticket' as nullable
            {
                ticket.Resolved = true;
                CreateTicketModel.Tickets[id] = ticket; // Updating dictionary to reflect resolved status
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
