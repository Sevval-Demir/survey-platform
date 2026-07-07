using System.ComponentModel.DataAnnotations;

namespace SurveyPlatform.Api.DTOs.Surveys;

public class CreateSurveyRequest
{
    [Required(ErrorMessage ="Anket baþlýðý zorunludur.")]
    [MinLength(3,ErrorMessage ="Baþlýk en az 3 karakter olmalýdýr.")]
    [MaxLength(150,ErrorMessage ="Baþlýk en fazla 150 karakter olabilir.")]
    public string Title { get; set; } = string.Empty;

    [MaxLength(1000,ErrorMessage ="Açýklama en fazla 1000 karakter olabilir.")]
    public string? Description { get; set; }
}
