using SurveyPlatform.Api.Data.Interfaces;
using SurveyPlatform.Api.Models;

namespace SurveyPlatform.Api.Data;

public class InMemorySurveyStore : ISurveyStore
{
    private readonly List<Survey> _surveys = new();
    private readonly object _syncRoot = new();

    public IReadOnlyList<Survey> GetAll()
    {
        lock (_syncRoot)
        {
            return _surveys.ToList();
        }
    }

    public Survey? GetById(Guid id)
    {
        lock (_syncRoot)
        {
            return _surveys.FirstOrDefault(survey => survey.Id == id);
        }
    }

    public void Add(Survey survey)
    {
        lock (_syncRoot)
        {
            _surveys.Add(survey);
        }
    }

    public void Update(Survey survey)
    {
        lock (_syncRoot)
        {
            var index = _surveys.FindIndex(existingSurvey => existingSurvey.Id == survey.Id);

            if (index >= 0)
            {
                _surveys[index] = survey;
            }
        }
    }

    public bool Delete(Guid id)
    {
        lock (_syncRoot)
        {
            var survey = _surveys.FirstOrDefault(existingSurvey => existingSurvey.Id == id);

            if (survey is null)
            {
                return false;
            }

            _surveys.Remove(survey);

            return true;
        }
    }
}
