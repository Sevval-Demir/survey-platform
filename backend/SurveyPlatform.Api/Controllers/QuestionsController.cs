using Microsoft.AspNetCore.Mvc;
using SurveyPlatform.Api.DTOs.Questions;
using SurveyPlatform.Api.Services.Interfaces;

namespace SurveyPlatform.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuestionsController : ControllerBase
{
    private readonly IQuestionService _questionService;

    public QuestionsController(IQuestionService questionService)
    {
        _questionService = questionService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<QuestionResponse>> GetAll()
    {
        return Ok(_questionService.GetAll());
    }

    [HttpGet("{id:guid}")]
    public ActionResult<QuestionResponse> GetById(Guid id)
    {
        var question = _questionService.GetById(id);

        if (question is null)
            return NotFound();

        return Ok(question);
    }

    [HttpPost]
    public ActionResult<QuestionResponse> Create(CreateQuestionRequest request)
    {
        if (!ModelState.IsValid)
            return ValidationProblem(ModelState);

        var question = _questionService.Create(request);

        return CreatedAtAction(nameof(GetById), new { id = question.Id }, question);
    }

    [HttpPut("{id:guid}")]
    public ActionResult<QuestionResponse> Update(Guid id, UpdateQuestionRequest request)
    {
        if (!ModelState.IsValid)
            return ValidationProblem(ModelState);

        var question = _questionService.Update(id, request);

        if (question is null)
            return NotFound();

        return Ok(question);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        var deleted = _questionService.Delete(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}