namespace SurveyPlatform.Api.Models;

public class Survey
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool IsActive { get; set; }
    public ICollection<Question> Questions { get; set; } = new List<Question>();
    public ICollection<Response> Responses { get; set; } = new List<Response>();
}
