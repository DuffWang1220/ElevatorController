using ElevatorController.Services.Interfaces;
using ElevatorController.Services.Repositories;
using ElevatorController.Services.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSingleton<IElevator, Elevator>();
builder.Services.AddSingleton<IElevatorRepository, ElevatorRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
