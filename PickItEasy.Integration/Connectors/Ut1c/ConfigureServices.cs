using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PickItEasy.Application.Interfaces.Integration;
using System.Net.Http.Headers;
using System.Text;

namespace PickItEasy.Integration.Connectors.Ut1c
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddConnectorUt1c(this IServiceCollection services, IConfiguration configuration)
        {
            var connectorName = nameof(Client1cUt);
            var connectorConfig = configuration
                .GetSection(IntegrationConfiguration.Section)
                .GetChildren()
                .FirstOrDefault(e => e.Get<ConnectorConfig>()?.Name == connectorName);
            var connector = connectorConfig?.Get<ConnectorConfig>()
                    ?? throw new ApplicationException($"Connector {connectorName} configuration not found.");

            services.AddHttpClient(connectorName, httpClient =>
            {
                httpClient.BaseAddress = new Uri(connector.BaseAddress);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (!string.IsNullOrEmpty(connector.UserName) && !string.IsNullOrEmpty(connector.Password))
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                        "Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{connector.UserName}:{connector.Password}")));
            });

            services.Configure<ConnectorConfig>(connectorName, connectorConfig);
            services.AddTransient<IClient1cUt, Client1cUt>();

            return services;
        }
    }
}
