using Microsoft.AspNetCore.Mvc;
using SurveyPlatform.Api.DTOs.Options;
using SurveyPlatform.Api.Services.Interfaces;

namespace SurveyPlatform.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OptionsController : ControllerBase
{
    private readonly IOptionService _optionService;

    public OptionsController(IOptionService optionService)
    {
        _optionService = optionService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<OptionResponse>> GetAll()
    {
        return Ok(_optionService.GetAll());
    }

    [HttpGet("{id:guid}")]
    public ActionResult<OptionResponse> GetById(Guid id)
    {
        var option = _optionService.GetById(id);

        if (option is null)
            return NotFound();

        return Ok(option);
    }

    [HttpPost]
    public ActionResult<OptionResponse> Create(CreateOptionRequest request)
    {
        if (!ModelState.IsValid)
            return ValidationProblem(ModelState);

        var option = _optionService.Create(request);

        return CreatedAtAction(nameof(GetById), new { id = option.Id }, option);
    }

    [HttpPut("{id:guid}")]
    public ActionResult<OptionResponse> Update(Guid id, UpdateOptionRequest request)
    {
        if (!ModelState.IsValid)
            return ValidationProblem(ModelState);

        var option = _optionService.Update(id, request);

        if (option is null)
            return NotFound();

        return Ok(option);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        var deleted = _optionService.Delete(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}