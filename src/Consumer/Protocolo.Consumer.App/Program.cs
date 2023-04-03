using Protocolo.Consumer.App.Configuration;
using Protocolo.Consumer.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDependencyInjection();
builder.Services.AddHostedService<InfoWorker>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
