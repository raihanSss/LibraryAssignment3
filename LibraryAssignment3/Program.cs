using Microsoft.EntityFrameworkCore;
using LibraryAssignment3.Models;
using LibraryAssignment3.Controllers;
using LibraryAssignment3.Interfaces;
using LibraryAssignment3.Services;
using LibraryAssignment3;
using LibraryAssignment3.Services.Library.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionStringPostgre = builder.Configuration.GetConnectionString("PostgreSQLConnection");
builder.Services.AddDbContext<libraryContext>(options => options.UseNpgsql(connectionStringPostgre));




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IBookService, BookService>();


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
