namespace SurveyPlatform.Api.Models
{
    public class Question
    {
        public Guid Id { get; set; }
        public Guid SurveyId { get; set; }
        public string Text { get; set; } = string.Empty;
        public string Type { get; set; } = "Text";
        public int Order { get; set; }
        public Survey Survey { get; set; } = null!;
        public ICollection<Option> Options { get; set; }
        public ICollection<Response> Responses { get; set; } = new List<Response>();
    }
}
