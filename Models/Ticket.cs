using System.ComponentModel.DataAnnotations;

public class Ticket
{
  public int Id { get; set; }

  [Required(ErrorMessage = "Description is required")]
  public string Description { get; set; } = string.Empty;

  [Required]
  public DateTime SubmissionTime { get; set; }

  [Required(ErrorMessage = "Resolution deadline is required")]
  public DateTime ResolutionDeadline { get; set; } = DateTime.Now;

  public bool Resolved { get; set; } = false;

  public bool IsDeadlineApproachingOrPassed()
  {
    var timeRemaining = ResolutionDeadline - DateTime.Now;
    return timeRemaining.TotalHours <= 1;
  }
}