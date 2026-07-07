using SurveyPlatform.Api.Data.Interfaces;
using SurveyPlatform.Api.DTOs.Options;
using SurveyPlatform.Api.Models;
using SurveyPlatform.Api.Services.Interfaces;

namespace SurveyPlatform.Api.Services.Implementations;

public class OptionService : IOptionService
{
    private readonly IOptionStore _optionStore;

    public OptionService(IOptionStore optionStore)
    {
        _optionStore = optionStore;
    }

    public IEnumerable<OptionResponse> GetAll()
    {
        return _optionStore
            .GetAll()
            .OrderBy(o => o.Order)
            .Select(MapToResponse)
            .ToList();
    }

    public OptionResponse? GetById(Guid id)
    {
        var option = _optionStore.GetById(id);

        return option is null ? null : MapToResponse(option);
    }

    public OptionResponse Create(CreateOptionRequest request)
    {
        var option = new Option
        {
            Id = Guid.NewGuid(),
            QuestionId = request.QuestionId,
            Text = request.Text.Trim(),
            Order = request.Order
        };

        _optionStore.Add(option);

        return MapToResponse(option);
    }

    public OptionResponse? Update(Guid id, UpdateOptionRequest request)
    {
        var option = _optionStore.GetById(id);

        if (option is null)
            return null;

        option.Text = request.Text.Trim();
        option.Order = request.Order;

        _optionStore.Update(option);

        return MapToResponse(option);
    }

    public bool Delete(Guid id)
    {
        return _optionStore.Delete(id);
    }

    private static OptionResponse MapToResponse(Option option)
    {
        return new OptionResponse
        {
            Id = option.Id,
            QuestionId = option.QuestionId,
            Text = option.Text,
            Order = option.Order
        };
    }
}