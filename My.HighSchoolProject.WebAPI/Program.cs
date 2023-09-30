using Microsoft.OpenApi.Models;
using My.HighSchoolProject.Business.Extensions;
using My.HighSchoolProject.DataAccess.InterFaces.IRepositories;
using My.HighSchoolProject.DataAccess.Models2;
using My.HighSchoolProject.DataAccess.Repositories;
using My.HighSchoolProject.WebAPI;
using Swashbuckle.AspNetCore.SwaggerGen;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDependencies();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My.HighSchoolProject.WebAPI", Version = "v1" });
});
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
