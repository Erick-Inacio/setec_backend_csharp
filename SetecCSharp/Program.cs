using System.Text.Json.Serialization;
using DotNetEnv;
using EvolveDb;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MySqlConnector;
using Serilog;
using SetecCSharp.db.Context;
using SetecCSharp.Middleware;
using SetecCSharp.Repositories.Generic;
using SetecCSharp.Repositories.Implements.Speaker;
using SetecCSharp.Repositories.Implements.Users;
using SetecCSharp.Services.Implements.Speaker;
using SetecCSharp.Services.Implements.Users;
using SetecCSharp.Services.Independents;

var builder = WebApplication.CreateBuilder(args);

Env.Load();

var firebaseKeyPath = Environment.GetEnvironmentVariable("FIREBASE_CREDENTIAL");
// Console.WriteLine("Path Firebase: " + firebaseKeyPath);


FirebaseApp.Create(new AppOptions()
{
    Credential = GoogleCredential.FromFile(firebaseKeyPath),
});

var appName = "Setec";
var appVersion = "v1";
var description = "API do sistema Setec";

// Add services to the container.

// Configuração de reescrita de URL para lowercase
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Habilitando CORS
builder.Services.AddCors(options => options.AddDefaultPolicy(
    builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    }
));

builder.Services.AddControllers(
    //Faz com que todos os endpoint nessecitem de autorização exceto os anotados com [AllowAnonymous]
    options =>
    {
        var policy = new AuthorizationPolicyBuilder()
            .RequireAuthenticatedUser()
            .Build();
        options.Filters.Add(new AuthorizeFilter(policy));
    })
    .AddJsonOptions(options =>
    {
        // Faz o enum aparecer o nome em string no swagger e no banco continuar como int
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

//Configuração do swagger
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
    c.SwaggerDoc(appVersion,
    new OpenApiInfo
    {
        Title = appName,
        Version = appVersion,
        Description = description,
        Contact = new OpenApiContact
        {
            Name = "Erick Inácio",
            Url = new Uri("https://github.com/ErickInacio")
            ,
        }
    });
});

var connection = builder.Configuration["MySqlConnection:MySqlConnectionString"];
builder.Services.AddDbContextPool<MySQLContext>(options => options.UseMySql(
    connection, new MySqlServerVersion(new Version(8, 0, 27)))
        .LogTo(Console.WriteLine, LogLevel.Information) // log EF
        .EnableSensitiveDataLogging()
);

if (builder.Environment.IsDevelopment())
{
    MigrateDatabase(connection!);
}

//Versioning API
builder.Services.AddApiVersioning();
//Dependency injection

//Admin 
builder.Services.AddScoped<AdminService>();

//User
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

//Speaker
builder.Services.AddScoped<ISpeakerService, SpeakerService>();
builder.Services.AddScoped<ISpeakerRepository, SpeakerRepository>();


// others Config
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

//Adicionando os profiles de AutoMapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

//Add CORS
app.UseCors();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint($"/swagger/v1/swagger.json",
        $"{appName} - {appVersion}");
});

var option = new RewriteOptions();
option.AddRedirect("^$", "swagger");
app.UseRewriter(option);

// Configurando middleware firebaseAuth e middleware de autenticação
app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthentication();
app.UseMiddleware<FirebaseAuthMiddleware>();

app.UseAuthorization();

app.MapControllers();

try
{
    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine("Erro fatal: " + ex.Message);
    throw;
}

static void MigrateDatabase(string connection)
{
    try
    {
        var envolveConnection = new MySqlConnection(connection);
        var evolve = new Evolve(envolveConnection, Log.Information)
        {
            Locations = ["db/migrations", "db/dataset"],
            IsEraseDisabled = true,
        };
        evolve.Migrate();
    }
    catch (EvolveException ex)
    {
        Console.WriteLine("Evolve migration failed: " + ex.Message);
        throw; // opcional, se quiser travar a aplicação
    }
}