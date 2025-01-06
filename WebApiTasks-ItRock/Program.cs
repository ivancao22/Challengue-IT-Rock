using Microsoft.EntityFrameworkCore;
using WebApiTasks_ItRock.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//agrego variable para guardar la cadena de conexion de la db
var connectionString = builder.Configuration.GetConnectionString("Connection");
//registro la conexion
builder.Services.AddDbContext<ApiDb>
(
    options => options.UseSqlServer(connectionString)
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
