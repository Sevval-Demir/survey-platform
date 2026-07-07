using System.ComponentModel.DataAnnotations;

namespace SurveyPlatform.Api.DTOs.Responses;

public class CreateResponseRequest
{
    [Required]
    public Guid SurveyId { get; set; }

    [Required]
    public Guid QuestionId { get; set; }

    [Required]
    public Guid OptionId { get; set; }

    public string? TextAnswer { get; set; }
}