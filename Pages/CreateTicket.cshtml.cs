using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class CreateTicketModel : PageModel
{
    private readonly ITicketService _ticketService;

    [BindProperty]
    public Ticket Ticket { get; set; } = new Ticket();

    public CreateTicketModel(ITicketService ticketService)
    {
        _ticketService = ticketService;
    }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (Ticket == null || !ModelState.IsValid)
        {
            return Page();
        }

        _ticketService.CreateTicket(Ticket);

        return RedirectToPage("./Index");
    }
}