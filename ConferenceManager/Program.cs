
using ConferenceManager.Controllers;
using ConferenceManager.Model;
using ConferenceManager.Service;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Text;

namespace ConferenceManager
{
    public class Program
    {

        public static void Main(string[] args)
        {
            byte[] key = Encoding.UTF8.GetBytes("0123456789-0123456789-0123456789");
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddHealthChecks()
                .AddCheck<EventsHealthCheck>("event_file_check",
                    failureStatus: HealthStatus.Unhealthy,
                    tags: new[] {"file", "events"});

            builder.Services.AddScoped<IEventService, EventService>();
            builder.Services.AddScoped<IEventModel, EventModel>();

            var app = builder.Build();

            app.UseHealthChecks("/health");
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
        }
    }
}
