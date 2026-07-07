namespace SurveyPlatform.Api.Models;

public class Response
{
    public Guid Id { get; set; }

    public Guid SurveyId { get; set; }

    public Guid QuestionId { get; set; }

    public Guid OptionId { get; set; }

    public string? TextAnswer { get; set; }

    public DateTime AnsweredAt { get; set; }

    public Survey Survey { get; set; } = null!;

    public Question Question { get; set; } = null!;

    public Option Option { get; set; } = null!;
}