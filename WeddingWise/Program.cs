using Hangfire;
using Microsoft.EntityFrameworkCore;
using Serilog;
using WeddingWise;
using WeddingWise.ServicesReposConfig;
using WeddingWise_Core.Context;
using WeddingWise_Core.IServices;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


//Db Context
builder.Services.AddDbContext<WeddingWiseDbContext>(x => x
                .UseLazyLoadingProxies()
                .UseSqlServer(builder.Configuration.GetConnectionString("Local")));

//Serilog and Documentation Configure

builder.Host.UseSerilog((context, configuration) =>
                     configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddSwaggerGenSerilog();

//Hangfire Configure

builder.Services
        .AddHangfire(configuration => configuration
        .UseSimpleAssemblyNameTypeSerializer()
        .UseRecommendedSerializerSettings()
        .UseSqlServerStorage(builder.Configuration.GetConnectionString("HangfireConnection")));


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
        s.SwaggerEndpoint("/swagger/v1.0/swagger.json", "WeddingWise");
    });
}


app.UseSerilogRequestLogging();

//Hangfire Configure
app.UseHangfireDashboard();
app.UseHangfireServer();

//When EndTime <= DateTime.Now
RecurringJob.AddOrUpdate<IClientServices>("update-reservation-statuses",
       service => service.RefreshReservationStatus(), Cron.MinuteInterval(3));

RecurringJob.AddOrUpdate<IAgentServices>("Update-Transaction-Status",
       service => service.UpdateTransactionStatus(), Cron.MinuteInterval(3));

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
