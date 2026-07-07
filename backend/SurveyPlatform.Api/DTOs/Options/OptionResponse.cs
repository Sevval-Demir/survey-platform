namespace SurveyPlatform.Api.DTOs.Options;

public class OptionResponse
{
    public Guid Id { get; set; }

    public Guid QuestionId { get; set; }

    public string Text { get; set; } = string.Empty;

    public int Order { get; set; }
}