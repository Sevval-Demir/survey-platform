namespace SurveyPlatform.Api.DTOs.Questions;

public class QuestionResponse
{
    public Guid Id { get; set; }

    public Guid SurveyId { get; set; }

    public string Text { get; set; } = string.Empty;

    public string Type { get; set; } = string.Empty;

    public int Order { get; set; }
}