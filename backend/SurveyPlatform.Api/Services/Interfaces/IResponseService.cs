using SurveyPlatform.Api.DTOs.Responses;

namespace SurveyPlatform.Api.Services.Interfaces;

public interface IResponseService
{
    IEnumerable<ResponseResponse> GetAll();

    ResponseResponse? GetById(Guid id);

    ResponseResponse Create(CreateResponseRequest request);

    ResponseResponse? Update(Guid id, UpdateResponseRequest request);

    bool Delete(Guid id);
}