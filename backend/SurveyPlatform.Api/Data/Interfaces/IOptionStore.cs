using SurveyPlatform.Api.Models;

namespace SurveyPlatform.Api.Data.Interfaces;

public interface IOptionStore
{
    IReadOnlyList<Option> GetAll();

    Option? GetById(Guid id);

    void Add(Option option);

    void Update(Option option);

    bool Delete(Guid id);
}