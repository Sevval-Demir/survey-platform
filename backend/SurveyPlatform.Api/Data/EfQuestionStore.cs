using Microsoft.EntityFrameworkCore;
using SurveyPlatform.Api.Data.Interfaces;
using SurveyPlatform.Api.Models;

namespace SurveyPlatform.Api.Data;

public class EfQuestionStore : IQuestionStore
{
    private readonly SurveyDbContext _context;

    public EfQuestionStore(SurveyDbContext context)
    {
        _context = context;
    }

    public IReadOnlyList<Question> GetAll()
    {
        return _context.Questions.ToList();
    }

    public Question? GetById(Guid id)
    {
        return _context.Questions.FirstOrDefault(q => q.Id == id);
    }

    public void Add(Question question)
    {
        _context.Questions.Add(question);
        _context.SaveChanges();
    }

    public void Update(Question question)
    {
        _context.Questions.Update(question);
        _context.SaveChanges();
    }

    public bool Delete(Guid id)
    {
        var question = _context.Questions.FirstOrDefault(q => q.Id == id);

        if (question is null)
            return false;

        _context.Questions.Remove(question);
        _context.SaveChanges();

        return true;
    }
}