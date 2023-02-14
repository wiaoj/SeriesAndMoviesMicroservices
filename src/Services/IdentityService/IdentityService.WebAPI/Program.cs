using IdentityService.Application;
using IdentityService.Persistence;
using Microsoft.OpenApi.Models;
using Spectre.Console;

AnsiConsole.Write(new FigletText("Identity Service").Centered().Color(Color.Chartreuse2));

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers();

builder.Services.AddCors(corsOptions =>
    corsOptions.AddDefaultPolicy(policy => {
        policy.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    })
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt => {
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description =
            """
            JWT Authorization header using the Bearer scheme. 

             Enter 'Bearer' [space] and then your token in the text input below.

            Example: "Bearer {{TOKEN}}"
            """
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer",
                }
            },
            Array.Empty<String>()
        }
    });
});

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

//if(app.Environment.IsProduction())
//    app.ConfigureCustomExceptionMiddleware();

//await app.Services.CreateAsyncScope()
//                    .ServiceProvider.GetRequiredService<IdentityDbContext>()
//                    .Database.MigrateAsync();


app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

await app.RunAsync();