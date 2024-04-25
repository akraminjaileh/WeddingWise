using Microsoft.EntityFrameworkCore;
using WeddingWise.ServicesReposConfig;
using WeddingWise_Core.Context;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Db Context
builder.Services.AddDbContext<WeddingWiseDbContext>(x =>
                x.UseSqlServer(builder.Configuration.GetConnectionString("Local")));

//Configure Services and Repos
builder.Services.ConfigureServices();

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