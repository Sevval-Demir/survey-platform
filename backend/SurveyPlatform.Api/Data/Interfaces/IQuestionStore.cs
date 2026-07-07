using SurveyPlatform.Api.Models;

namespace SurveyPlatform.Api.Data.Interfaces;

public interface IQuestionStore
{
    IReadOnlyList<Question> GetAll();

    Question? GetById(Guid id);

    void Add(Question question);

    void Update(Question question);

    bool Delete(Guid id);
}