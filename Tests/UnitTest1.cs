using Xunit;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

public class UnitTest1
{
    [Fact]
    public void Ticket_ShouldRequireDescription()
    {
        // Arrange
        var ticket = new Ticket { Description = "", SubmissionTime = DateTime.Now, ResolutionDeadline = DateTime.Now.AddDays(1) };

        // Act
        var validationResults = ValidateModel(ticket);

        // Assert
        Assert.Contains(validationResults, v => v.MemberNames != null && v.MemberNames.Contains("Description") && v.ErrorMessage != null && v.ErrorMessage.Contains("required"));
    }

    [Fact]
    public void Ticket_DefaultsToUnresolved()
    {
        // Arrange
        var ticket = new Ticket();

        // Act
        var result = ticket.Resolved;

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void Ticket_DefaultsToUnresolved_WhenCreatedWithDescriptionAndTimes()
    {
        // Arrange
        var ticket = new Ticket { Description = "Test ticket", SubmissionTime = DateTime.Now, ResolutionDeadline = DateTime.Now.AddDays(1) };

        // Act
        var result = ticket.Resolved;

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void Ticket_IsDeadlineApproachingOrPassed_ReturnsTrue_IfDeadlineWithinOneHour()
    {
        // Arrange
        var ticket = new Ticket
        {
            ResolutionDeadline = DateTime.Now.AddMinutes(30)  // Less than 1 hour away
        };

        // Act
        bool result = ticket.IsDeadlineApproachingOrPassed();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Ticket_IsDeadlineApproachingOrPassed_ReturnsTrue_IfDeadlineExactlyOneHourAway()
    {
        // Arrange
        var ticket = new Ticket
        {
            ResolutionDeadline = DateTime.Now.AddHours(1)  // Exactly 1 hour away
        };

        // Act
        bool result = ticket.IsDeadlineApproachingOrPassed();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Ticket_IsDeadlineApproachingOrPassed_ReturnsFalse_IfDeadlineMoreThanOneHourAway()
    {
        // Arrange
        var ticket = new Ticket
        {
            ResolutionDeadline = DateTime.Now.AddHours(2)  // More than 1 hour away
        };

        // Act
        bool result = ticket.IsDeadlineApproachingOrPassed();

        // Assert
        Assert.False(result);
    }

    private List<ValidationResult> ValidateModel(object model)
    {
        var validationResults = new List<ValidationResult>();
        var ctx = new ValidationContext(model, null, null);
        Validator.TryValidateObject(model, ctx, validationResults, true);
        return validationResults;
    }
}