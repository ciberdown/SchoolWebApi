using Microsoft.EntityFrameworkCore;
using SchoolWebApi.src.Data;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region Configure-SQLite
builder.Services.AddDbContext<SchoolDb>(options =>
    options.UseSqlite("Data Source=schoolDb.db"));
#endregion

#region inject-services
//builder.Services.AddScoped<ISchoolRepo, SchoolRepo>();
//builder.Services.AddScoped<ISchoolAppService, SchoolAppService>();

//builder.Services.AddScoped<IStudentRepo, StudentRepo>();
//builder.Services.AddScoped<IStudentAppService, StudentAppService>();

//builder.Services.AddScoped<ICourseRepo, CourseRepo>();
//builder.Services.AddScoped<ICourseAppService, CourseAppService>();

//builder.Services.AddScoped<IStudentCourseRepo, StudentCourseRepo>();
//builder.Services.AddScoped<IStudentCourseAppService, StudentCourseAppService>();
var assembly = Assembly.GetExecutingAssembly();

// Register Repositories
var repositories = assembly.GetTypes()
    .Where(t => t.IsClass && !t.IsAbstract && t.Name.EndsWith("Repository"))
    .Select(t => new
    {
        Interface = t.GetInterface($"I{t.Name}"), // Find corresponding interface
        Implementation = t
    })
    .Where(t => t.Interface != null); // Ensure interface exists

foreach (var repo in repositories)
{
    builder.Services.AddScoped(repo.Interface, repo.Implementation);
}

// Register AppServices
var appServices = assembly.GetTypes()
    .Where(t => t.IsClass && !t.IsAbstract && t.Name.EndsWith("AppService"))
    .Select(t => new
    {
        Interface = t.GetInterface($"I{t.Name}"), // Find corresponding interface
        Implementation = t
    })
    .Where(t => t.Interface != null); // Ensure interface exists

foreach (var service in appServices)
{
    builder.Services.AddScoped(service.Interface, service.Implementation);
}
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
