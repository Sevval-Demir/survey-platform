using System.ComponentModel.DataAnnotations;

namespace SurveyPlatform.Api.DTOs.Responses;

public class UpdateResponseRequest
{
    [Required]
    public Guid OptionId { get; set; }

    public string? TextAnswer { get; set; }
}