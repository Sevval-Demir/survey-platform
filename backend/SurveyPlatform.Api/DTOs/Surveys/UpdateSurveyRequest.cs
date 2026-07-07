using System.ComponentModel.DataAnnotations;

namespace SurveyPlatform.Api.DTOs.Surveys;

public class UpdateSurveyRequest
{
    [Required]
    [MaxLength(150)]
    public string Title { get; set; } = string.Empty;

    [MaxLength(1000)]
    public string? Description { get; set; }

    public bool IsActive { get; set; }
}
