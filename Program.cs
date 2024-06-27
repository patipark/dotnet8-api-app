
using DotnetAPIApp.Data;
using DotnetAPIApp.Services.ThaiDate;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add DbContext Service named 'MySQLDbContext'
builder.Services.AddDbContext<MySQLDbContext>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Custom Service
builder.Services.AddScoped<IThaiDate, ThaiDate>();
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
