using System;
using System.Collections.Concurrent;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class CreateTicketModel : PageModel
{
    [BindProperty]
    public Ticket Ticket { get; set; } = new Ticket();

    public static ConcurrentDictionary<int, Ticket> Tickets = new ConcurrentDictionary<int, Ticket>();
    public static ConcurrentDictionary<int, Ticket> ResolvedTickets = new ConcurrentDictionary<int, Ticket>();

    public void OnGet()
    {
    }

    public IActionResult OnPost()
{
    if (Ticket == null || !ModelState.IsValid)
    {
        return Page();
    }

    int newId = Tickets.Count > 0 ? Tickets.Keys.Max() + 1 : 1;
    Ticket.Id = newId;
    Ticket.SubmissionTime = DateTime.Now;

    if (!Tickets.TryAdd(newId, Ticket))
    {
        ModelState.AddModelError("", "Could not add the ticket due to a concurrency issue.");
        return Page();
    }

    return RedirectToPage("./Index");
}

}

