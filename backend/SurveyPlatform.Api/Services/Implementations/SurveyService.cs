using SurveyPlatform.Api.Data.Interfaces;
using SurveyPlatform.Api.DTOs.Surveys;
using SurveyPlatform.Api.Models;
using SurveyPlatform.Api.Services.Interfaces;

namespace SurveyPlatform.Api.Services.Implementations;

public class SurveyService : ISurveyService
{
    private readonly ISurveyStore _surveyStore;

    public SurveyService(ISurveyStore surveyStore)
    {
        _surveyStore = surveyStore;
    }

    public IEnumerable<SurveyResponse> GetAll()
    {
        return _surveyStore
            .GetAll()
            .OrderByDescending(survey => survey.CreatedAt)
            .Select(MapToResponse)
            .ToList();
    }

    public SurveyResponse? GetById(Guid id)
    {
        var survey = _surveyStore.GetById(id);

        return survey is null ? null : MapToResponse(survey);
    }

    public SurveyResponse Create(CreateSurveyRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Title))
        {
            throw new ArgumentException("Anket baþlýðý boþ olamaz.");
        }
        var survey = new Survey
        {
            Id = Guid.NewGuid(),
            Title = request.Title.Trim(),
            Description = request.Description?.Trim(),
            CreatedAt = DateTime.UtcNow,
            IsActive = true
        };

        _surveyStore.Add(survey);

        return MapToResponse(survey);
    }

    public SurveyResponse? Update(Guid id, UpdateSurveyRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Title)) 
        {
            throw new ArgumentException("Anket baþlýðý boþ olamaz.");
        }
        var survey = _surveyStore.GetById(id);

        if (survey is null)
        {
            return null;
        }

        survey.Title = request.Title.Trim();
        survey.Description = request.Description?.Trim();
        survey.IsActive = request.IsActive;
        survey.UpdatedAt = DateTime.UtcNow;

        _surveyStore.Update(survey);

        return MapToResponse(survey);
    }

    public bool Delete(Guid id)
    {
        return _surveyStore.Delete(id);
    }

    private static SurveyResponse MapToResponse(Survey survey)
    {
        return new SurveyResponse
        {
            Id = survey.Id,
            Title = survey.Title,
            Description = survey.Description,
            CreatedAt = survey.CreatedAt,
            UpdatedAt = survey.UpdatedAt,
            IsActive = survey.IsActive
        };
    }
}
