using SurveyPlatform.Api.DTOs.Questions;

namespace SurveyPlatform.Api.Services.Interfaces;

public interface IQuestionService
{
    IEnumerable<QuestionResponse> GetAll();

    QuestionResponse? GetById(Guid id);

    QuestionResponse Create(CreateQuestionRequest request);

    QuestionResponse? Update(Guid id, UpdateQuestionRequest request);

    bool Delete(Guid id);
}