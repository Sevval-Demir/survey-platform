using SurveyPlatform.Api.DTOs.Options;

namespace SurveyPlatform.Api.Services.Interfaces;

public interface IOptionService
{
    IEnumerable<OptionResponse> GetAll();

    OptionResponse? GetById(Guid id);

    OptionResponse Create(CreateOptionRequest request);

    OptionResponse? Update(Guid id, UpdateOptionRequest request);

    bool Delete(Guid id);
}