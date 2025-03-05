using BusinessLayer.Interface;
using BusinessLayer.Service;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using RepositoryLayer.Context;
using RepositoryLayer.Interface;
//using RepositoryLayer.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register Business Layer and Repository Layer
builder.Services.AddDbContext<GreetingContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBCON")));
builder.Services.AddScoped<IGreetingBL, GreetingBL>();
builder.Services.AddScoped<IGreetingRL, GreetingRL>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
