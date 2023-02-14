using CategoryService.Application;
using CategoryService.Infrastructure;
using CategoryService.Persistence;
using CategoryService.Persistence.Contexts;
using CategoryService.Persistence.Contexts.Settings;
using EventBus.Base;
using EventBus.Base.Abstraction;
using EventBus.Factory;
using EventBus.RabbitMQ;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using Spectre.Console;

AnsiConsole.Write(new FigletText("Category Service").Centered().Color(Color.Orange1));

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddHttpContextAccessor();

//builder.Services.AddTransient<TestIntegrationEventHandler>();

//builder.Services.AddSingleton<IEventBus>(serviceProvider => {

//    EventBusConfig eventBusConfig = new() {
//        ConnectionRetryCount = 5,
//        EventNameSuffix = "IntegrationEvent",
//        SubscriberClientApplicationName = "CategoryService",
//        EventBusType = EventBusType.RabbitMQ,
//    };
//    return EventBusFactory.Create(eventBusConfig, serviceProvider);
//});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    options => {
        options.SwaggerDoc("v1", new() {
            Title = "Category Service",
            Version = "v1",
            Description = "Category Service OpenApi",
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
           options.SwaggerEndpoint($"{(String.IsNullOrEmpty(pathBase) is false ? pathBase : String.Empty)}/swagger/v1/swagger.json", "Category.API v1");
           //options.SwaggerEndpoint($"/swagger/v2/swagger.json", "Category.API v2");
       });
}

await app.Services.CreateAsyncScope()
                  .ServiceProvider.GetRequiredService<CategoryDbContext>()
                  .Database.MigrateAsync();

//IEventBus eventBus = app.Services.GetRequiredService<IEventBus>();
//eventBus.Subscribe<TestIntegrationEvent, TestIntegrationEventHandler>();

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
