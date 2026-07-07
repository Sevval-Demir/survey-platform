using System.ComponentModel.DataAnnotations;

namespace SurveyPlatform.Api.DTOs.Options;

public class UpdateOptionRequest
{
    [Required]
    [MaxLength(250)]
    public string Text { get; set; } = string.Empty;

    public int Order { get; set; }
}