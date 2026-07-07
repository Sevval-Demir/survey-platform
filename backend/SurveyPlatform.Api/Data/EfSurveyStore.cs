using Microsoft.EntityFrameworkCore;
using SurveyPlatform.Api.Data.Interfaces;
using SurveyPlatform.Api.Models;

namespace SurveyPlatform.Api.Data
{
    public class EfSurveyStore : ISurveyStore
    {
        private readonly SurveyDbContext _context;

        public EfSurveyStore(SurveyDbContext context)
        {
            _context = context;
        }

        public IReadOnlyList<Survey> GetAll()
        {
            return _context.Surveys.ToList();
        }

        public Survey? GetById(Guid id)
        {
            return _context.Surveys.FirstOrDefault(s => s.Id == id);
        }

        public void Add(Survey survey)
        {
            _context.Surveys.Add(survey);
            _context.SaveChanges();
        }

        public void Update(Survey survey)
        {
            _context.Surveys.Update(survey);
            _context.SaveChanges();
        }

        public bool Delete(Guid id)
        {
            var survey = _context.Surveys.FirstOrDefault(s => s.Id == id);

            if (survey is null)
                return false;

            _context.Surveys.Remove(survey);
            _context.SaveChanges();

            return true;
        }
    }
}

