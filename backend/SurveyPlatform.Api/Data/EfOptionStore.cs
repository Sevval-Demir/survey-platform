using SurveyPlatform.Api.Data.Interfaces;
using SurveyPlatform.Api.Models;

namespace SurveyPlatform.Api.Data;

public class EfOptionStore : IOptionStore
{
    private readonly SurveyDbContext _context;

    public EfOptionStore(SurveyDbContext context)
    {
        _context = context;
    }

    public IReadOnlyList<Option> GetAll()
    {
        return _context.Options.ToList();
    }

    public Option? GetById(Guid id)
    {
        return _context.Options.FirstOrDefault(o => o.Id == id);
    }

    public void Add(Option option)
    {
        _context.Options.Add(option);
        _context.SaveChanges();
    }

    public void Update(Option option)
    {
        _context.Options.Update(option);
        _context.SaveChanges();
    }

    public bool Delete(Guid id)
    {
        var option = _context.Options.FirstOrDefault(o => o.Id == id);

        if (option is null)
            return false;

        _context.Options.Remove(option);
        _context.SaveChanges();

        return true;
    }
}