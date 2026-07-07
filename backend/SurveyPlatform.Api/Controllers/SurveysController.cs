using Microsoft.AspNetCore.Mvc;
using SurveyPlatform.Api.DTOs.Surveys;
using SurveyPlatform.Api.Services.Interfaces;

namespace SurveyPlatform.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SurveysController : ControllerBase
{
    private readonly ISurveyService _surveyService;

    public SurveysController(ISurveyService surveyService)
    {
        _surveyService = surveyService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<SurveyResponse>> GetAll()
    {
        var surveys = _surveyService.GetAll();

        return Ok(surveys);
    }

    [HttpGet("{id:guid}")]
    public ActionResult<SurveyResponse> GetById(Guid id)
    {
        var survey = _surveyService.GetById(id);

        if (survey is null)
        {
            return NotFound();
        }

        return Ok(survey);
    }

    [HttpPost]
    public ActionResult<SurveyResponse> Create(CreateSurveyRequest request)
    {
        var survey = _surveyService.Create(request);

        return CreatedAtAction(nameof(GetById), new { id = survey.Id }, survey);
    }

    [HttpPut("{id:guid}")]
    public ActionResult<SurveyResponse> Update(Guid id, UpdateSurveyRequest request)
    {
        var survey = _surveyService.Update(id, request);

        if (survey is null)
        {
            return NotFound();
        }

        return Ok(survey);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        var deleted = _surveyService.Delete(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}

