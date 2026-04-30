using ConferenceManager.Model.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;

namespace ConferenceManager.Controllers
{
    public class EventsHealthCheck : IHealthCheck
    {
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var jsonFilePath = @"Resources\EventData.json";

            var jsonData = await File.ReadAllTextAsync(jsonFilePath);

            var productsData = JsonSerializer.Deserialize<List<Event>>(jsonData);

            int products = productsData.Count();

            if (products > 0)
            {
                return HealthCheckResult.Healthy($"There are {products} products available.");
            }
            else
            {
                return HealthCheckResult.Unhealthy($"There are {products} products available.");
            }
        }
    }
}
