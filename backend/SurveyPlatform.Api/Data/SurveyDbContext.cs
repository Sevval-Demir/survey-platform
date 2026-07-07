using Microsoft.EntityFrameworkCore;
using SurveyPlatform.Api.Models;

namespace SurveyPlatform.Api.Data
{
    public class SurveyDbContext : DbContext
    {

        public SurveyDbContext(DbContextOptions<SurveyDbContext> options) : base(options)
        {

        }
        public DbSet<Survey> Surveys { get; set; }
    }
}
