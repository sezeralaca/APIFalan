using Microsoft.EntityFrameworkCore;
using IDoContent.Models;
using IDoContent.Data;

var builder = WebApplication.CreateBuilder(args);

 // Add services to the container.

//builder.Services.AddDbContext<APIContext>(opt => opt.UseInMemoryDatabase("ContentDB"));
builder.Services.AddDbContext<APIContext>(options =>
{
    options.UseSqlServer("Server=104.247.167.130\\MSSQLSERVER2022;Database=sezerala_api;User Id=sezerala_api;Password=Bzs2p582@;TrustServerCertificate=True");
});

builder.Services.AddControllers();
 builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);

var app = builder.Build();

// Configure the HTTP request pipeline.
 
    app.UseSwagger();
    app.UseSwaggerUI();
 
//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
