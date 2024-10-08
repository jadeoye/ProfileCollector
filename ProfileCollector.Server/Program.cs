using ProfileCollector.Infrastructure.DependencyInjections;
using System.Reflection;
using MediatR;
using FluentValidation;
using ProfileCollector.Application.DependencyInjections;
using ProfileCollector.Server.Middlewares;
using ProfileCollector.Infrastructure.Interfaces;
using ProfileCollector.Infrastructure.Logging;
using ProfileCollector.Server.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ApiExceptionFilterAttribute>();
    options.Filters.Add<ExceptionLoggerFilter>();
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IExceptionLogger, ExceptionLogger>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ExceptionLoggerMiddleware>();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
