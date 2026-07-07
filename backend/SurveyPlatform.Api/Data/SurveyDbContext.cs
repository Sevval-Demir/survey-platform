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
        public DbSet<Question> Questions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Question>()
                .HasOne(q => q.Survey)
                .WithMany(s => s.Questions)
                .HasForeignKey(q => q.SurveyId);
            modelBuilder.Entity<Option>()
                .HasOne(o => o.Question)
                .WithMany(q => q.Options)
                .HasForeignKey(o => o.QuestionId);
            modelBuilder.Entity<Response>()
                .HasOne(r=>r.Survey)
                .WithMany(s=>s.Responses)
                .HasForeignKey(r => r.SurveyId);
            modelBuilder.Entity<Response>()
    .HasOne(r => r.Question)
    .WithMany(q => q.Responses)
    .HasForeignKey(r => r.QuestionId);
            modelBuilder.Entity<Response>()
    .HasOne(r => r.Option)
    .WithMany(o => o.Responses)
    .HasForeignKey(r => r.OptionId);
        }
        public DbSet<Option> Options { get; set; }
       public DbSet<Response> Responses { get; set; }
    }
}
