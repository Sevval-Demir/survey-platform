using SurveyPlatform.Api.Models;

namespace SurveyPlatform.Api.Data.Interfaces;

public interface IResponseStore
{
    IReadOnlyList<Response> GetAll();

    Response? GetById(Guid id);

    void Add(Response response);

    void Update(Response response);

    bool Delete(Guid id);
}