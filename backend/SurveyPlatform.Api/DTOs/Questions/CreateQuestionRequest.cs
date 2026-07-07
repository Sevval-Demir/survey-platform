using System.ComponentModel.DataAnnotations;

namespace SurveyPlatform.Api.DTOs.Questions;

public class CreateQuestionRequest
{
    [Required]
    public Guid SurveyId { get; set; }

    [Required]
    [MaxLength(500)]
    public string Text { get; set; } = string.Empty;

    [Required]
    public string Type { get; set; } = "Text";

    public int Order { get; set; }
}