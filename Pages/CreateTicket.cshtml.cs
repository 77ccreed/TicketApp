using System.Collections.Concurrent;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class CreateTicketModel : PageModel
{
    [BindProperty]
    public Ticket Ticket { get; set; } = new Ticket();

    public static ConcurrentDictionary<int, Ticket> Tickets = new ConcurrentDictionary<int, Ticket>();
    public static ConcurrentDictionary<int, Ticket> ResolvedTickets = new ConcurrentDictionary<int, Ticket>();

    // Global variable to hold the next ticket ID
    private static int NextTicketId = 1;

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (Ticket == null || !ModelState.IsValid)
        {
            return Page();
        }

        // Use the global variable for the new ticket ID
        Ticket.Id = NextTicketId++;
        Ticket.SubmissionTime = DateTime.Now;

        if (!Tickets.TryAdd(Ticket.Id, Ticket))
        {
            ModelState.AddModelError("", "Could not add the ticket due to a concurrency issue.");
            return Page();
        }

        return RedirectToPage("./Index");
    }
}