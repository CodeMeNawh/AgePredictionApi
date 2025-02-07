using AgePredictionApi.Interfaces;
using AgePredictionApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AgePredictionApi.Services
{
    public class AgeService : IAgeService
    {
        private readonly HttpClient _httpClient;

        public AgeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<AgePrediction> GetAgePredictionAsync(string name)
        {
            var response = await _httpClient.GetFromJsonAsync<AgePrediction>($"?name={name}");

            return response;
        }
    }
}
