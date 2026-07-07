namespace SurveyPlatform.Api.DTOs.Responses;

public class ResponseResponse
{
    public Guid Id { get; set; }

    public Guid SurveyId { get; set; }

    public Guid QuestionId { get; set; }

    public Guid OptionId { get; set; }

    public string? TextAnswer { get; set; }

    public DateTime AnsweredAt { get; set; }
}