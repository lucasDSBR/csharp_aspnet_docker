using TWJobs.Core.Config;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterDatabase();
builder.Services.RegisterRepositories();
builder.Services.RegisterServices();
builder.Services.RegisterMappers();
builder.Services.RegisterValidators();
builder.Services.RegisterAssemblers();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.RegisterDocumentation();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.RegisterMiddlewares();

app.Run();
