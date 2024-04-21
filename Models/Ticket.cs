using System.ComponentModel.DataAnnotations;

public class Ticket
{
  public int Id { get; set; }

  [Required(ErrorMessage = "Description is required")]
  public string Description { get; set; } = string.Empty;

  [Required]
  public DateTimeOffset SubmissionTime { get; set; }

  [Required(ErrorMessage = "Resolution deadline is required")]
  public DateTimeOffset ResolutionDeadline { get; set; } = DateTimeOffset.Now;

  public bool Resolved { get; set; } = false;

  public void Resolve()
  {
    Resolved = true;
  }

  public void Unresolve()
  {
    Resolved = false;
  }

  public bool IsDeadlineApproachingOrPassed(int hoursBeforeDeadline = 1)
  {
    var timeRemaining = ResolutionDeadline - DateTimeOffset.Now;
    return timeRemaining.TotalHours <= hoursBeforeDeadline;
  }
}