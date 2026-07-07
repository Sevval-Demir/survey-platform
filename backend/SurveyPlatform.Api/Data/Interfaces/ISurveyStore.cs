using SurveyPlatform.Api.Models;

namespace SurveyPlatform.Api.Data.Interfaces;

public interface ISurveyStore
{
    IReadOnlyList<Survey> GetAll();

    Survey? GetById(Guid id);

    void Add(Survey survey);

    void Update(Survey survey);

    bool Delete(Guid id);
}
