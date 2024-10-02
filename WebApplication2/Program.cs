using Microsoft.EntityFrameworkCore;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Entities; // Adjust this if your context is in a different namespace

var builder = WebApplication.CreateBuilder(args);
// Configure the database context
builder.Services.AddDbContext<EntitiesDbContext>(options =>
    options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"));

// Add services to the container.
builder.Services.AddControllers();
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
