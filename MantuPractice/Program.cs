using MantuPractice.Domain.Models;
using MantuPractice.Startup;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Scalar.AspNetCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.AddDependencies();
builder.Services.AddMantuServices();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
 

builder.Services.AddDbContext<BdeComDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

});
var app = builder.Build();
app.UseOpenApi();
app.UseHttpsRedirection();
app.ApplyCorsConfig();

app.UseAuthorization();
app.MapControllers();
//app.MapGet("/scalar/v1", () => "Hello World");
app.Run();
