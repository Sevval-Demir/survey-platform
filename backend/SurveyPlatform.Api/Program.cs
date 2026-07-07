using SurveyPlatform.Api.Data;
using SurveyPlatform.Api.Data.Interfaces;
using SurveyPlatform.Api.Services.Implementations;
using SurveyPlatform.Api.Services.Interfaces;
using SurveyPlatform.Api.Middleware;
using Microsoft.EntityFrameworkCore; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<SurveyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ISurveyStore, EfSurveyStore>();
builder.Services.AddScoped<ISurveyService, SurveyService>();

builder.Services.AddScoped<IQuestionStore, EfQuestionStore>();
builder.Services.AddScoped<IQuestionService, QuestionService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IOptionStore, EfOptionStore>();
builder.Services.AddScoped<IOptionService, OptionService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
