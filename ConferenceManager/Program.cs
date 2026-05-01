
using ConferenceManager.Controllers;
using ConferenceManager.Middleware;
using ConferenceManager.Model;
using ConferenceManager.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ConferenceManager
{
    public class Program
    {

        public static void Main(string[] args)
        {
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
            builder.Services.AddScoped<IAttendeeService, AttendeeService>();
            builder.Services.AddScoped<IAttendeeModel, AttendeeModel>();
            builder.Services.AddScoped<ISpeakerService, SpeakerService>();
            builder.Services.AddScoped<ISpeakerModel, SpeakerModel>();

            builder.Services.AddTransient<AuthorisationMiddleware>();

            var key = Encoding.UTF8.GetBytes("0123456789-0123456789-0123456789");
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = "your-name",
                        ValidateAudience = true,
                        ValidAudience = "your-app-name",
                        ValidateLifetime = false,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key)
                    };
                });

            var app = builder.Build();

            app.UseHealthChecks("/health");
            app.UseMiddleware<AuthorisationMiddleware>();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
