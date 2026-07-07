using SurveyPlatform.Api.Data.Interfaces;
using SurveyPlatform.Api.DTOs.Questions;
using SurveyPlatform.Api.Models;
using SurveyPlatform.Api.Services.Interfaces;

namespace SurveyPlatform.Api.Services.Implementations;

public class QuestionService : IQuestionService
{
    private readonly IQuestionStore _questionStore;

    public QuestionService(IQuestionStore questionStore)
    {
        _questionStore = questionStore;
    }

    public IEnumerable<QuestionResponse> GetAll()
    {
        return _questionStore
            .GetAll()
            .OrderBy(q => q.Order)
            .Select(MapToResponse)
            .ToList();
    }

    public QuestionResponse? GetById(Guid id)
    {
        var question = _questionStore.GetById(id);

        return question is null ? null : MapToResponse(question);
    }

    public QuestionResponse Create(CreateQuestionRequest request)
    {
        var question = new Question
        {
            Id = Guid.NewGuid(),
            SurveyId = request.SurveyId,
            Text = request.Text.Trim(),
            Type = request.Type.Trim(),
            Order = request.Order
        };

        _questionStore.Add(question);

        return MapToResponse(question);
    }

    public QuestionResponse? Update(Guid id, UpdateQuestionRequest request)
    {
        var question = _questionStore.GetById(id);

        if (question is null)
            return null;

        question.Text = request.Text.Trim();
        question.Type = request.Type.Trim();
        question.Order = request.Order;

        _questionStore.Update(question);

        return MapToResponse(question);
    }

    public bool Delete(Guid id)
    {
        return _questionStore.Delete(id);
    }

    private static QuestionResponse MapToResponse(Question question)
    {
        return new QuestionResponse
        {
            Id = question.Id,
            SurveyId = question.SurveyId,
            Text = question.Text,
            Type = question.Type,
            Order = question.Order
        };
    }
}