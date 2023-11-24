using Microsoft.Extensions.Diagnostics.HealthChecks;
using RestSharp;

namespace API.Services.Health
{
    public class ApiHealthCheck : IHealthCheck
    {
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var url = "https://localhost:5002/WeatherForecast";

            var client = new RestClient();

            var request = new RestRequest(url, Method.Get);
            request.AddHeader("Accept", "application/json");

            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                return HealthCheckResult.Healthy();
            }
            else
            {
                return HealthCheckResult.Unhealthy();
            }
        }
    }
}
