using SurveyPlatform.Api.DTOs.Surveys;

namespace SurveyPlatform.Api.Services.Interfaces;

public interface ISurveyService
{
    IEnumerable<SurveyResponse> GetAll();

    SurveyResponse? GetById(Guid id);

    SurveyResponse Create(CreateSurveyRequest request);

    SurveyResponse? Update(Guid id, UpdateSurveyRequest request);

    bool Delete(Guid id);
}
