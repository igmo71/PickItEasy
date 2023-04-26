using Microsoft.Extensions.Options;
using PickItEasy.Application.Interfaces.Integration;
using PickItEasy.Application.Models.WhsOrder.Out.Dto;
using PickItEasy.Domain.Entities;
using System.Net;
using System.Net.Mime;
using System.Text;
using System.Text.Json;

namespace PickItEasy.Integration.Connectors.Ut1c
{
    public class Client1cUt : IClient1cUt
    {
        public const string connectorName = nameof(Client1cUt);
        private readonly HttpClient _client1cUt;
        private readonly ConnectorConfig _connectorConfig;
        private readonly ServiceConfig _httpServiceConfig;
        private readonly JsonSerializerOptions _serializerOptions;

        public Client1cUt(IHttpClientFactory clientFactory, IOptionsSnapshot<ConnectorConfig> namedOptionsAccessor)
        {
            _client1cUt = clientFactory.CreateClient(connectorName);
            _connectorConfig = namedOptionsAccessor.Get(connectorName);
            _httpServiceConfig = _connectorConfig.Services?.FirstOrDefault(e => e.Name == "HttpService")
                ?? throw new ApplicationException($"{connectorName} HttpService configuration not found.");
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<string> PostWhsOrderOutAsync(WhsOrderOutDto whsOrderOutDto)
        {
            try
            {
                var content = JsonSerializer.Serialize(whsOrderOutDto);
                var stringContent = new StringContent(content, Encoding.UTF8, MediaTypeNames.Application.Json);
                var requestUri = $"{_httpServiceConfig.Url}/{nameof(WhsOrderOut)}";
                var response = await _client1cUt.PutAsync(requestUri, stringContent);
                return response.StatusCode.ToString();
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync($"Error: {ex.Message}");
                //throw;
            }
            return HttpStatusCode.ServiceUnavailable.ToString();
        }
    }
}