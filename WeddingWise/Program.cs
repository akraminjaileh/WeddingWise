using Microsoft.EntityFrameworkCore;
using Serilog;
using WeddingWise;
using WeddingWise.ServicesReposConfig;
using WeddingWise_Core.Context;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();



//Db Context
builder.Services.AddDbContext<WeddingWiseDbContext>(x => x
                .UseLazyLoadingProxies()
                .UseSqlServer(builder.Configuration.GetConnectionString("Local")));

//Serilog Start

builder.Host.UseSerilog((context, configuration) =>
                     configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddSwaggerGenSerilog();

//Serilog End

//Configure Services and Repos
builder.Services.ConfigureServices();

var app = builder.Build();


Log.Information("Starting web host");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(s =>
    {
        s.SwaggerEndpoint("/swagger/v1.0/swagger.json", "Your Project");
    });
}


app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
