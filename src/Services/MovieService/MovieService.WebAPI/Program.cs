using Microsoft.EntityFrameworkCore;
using MovieService.Application;
using MovieService.Infrastructure;
using MovieService.Persistence;
using MovieService.Persistence.Context;
using Spectre.Console;

AnsiConsole.Write(new FigletText("Movie Service").Centered().Color(Color.Purple_2));

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    options => {
        options.SwaggerDoc("v1", new() {
            Title = "Movie Service",
            Version = "v1",
            Description = "Movie Service OpenApi",
            Contact = new() {
                Email = "bertan@bertan.com",
                Name = "Bertan",
                Url = new("https://bertan.com/")
            },
            TermsOfService = new("https://bertan.com/termsOfService"),
            License = new() {
                Name = "License",
                Url = new("https://bertan.com/license"),

            },
        });
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment()) {
    var pathBase = String.Empty;//app.Configuration["PATH_BASE"];
    app.UseSwagger()
       .UseSwaggerUI(options => {
           options.SwaggerEndpoint($"{(String.IsNullOrEmpty(pathBase) is false ? pathBase : String.Empty)}/swagger/v1/swagger.json", "Movie.API v1");
           //options.SwaggerEndpoint($"/swagger/v2/swagger.json", "Movie.API v2");
       });
}
//await app.Services.CreateAsyncScope()
//                  .ServiceProvider.GetRequiredService<MovieDbContext>()
//                  .Database.MigrateAsync();

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
