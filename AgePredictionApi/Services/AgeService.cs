using AgePredictionApi.Data;
using AgePredictionApi.Interfaces;
using AgePredictionApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace AgePredictionApi.Services
{
    public class AgeService : IAgeService
    {
        private readonly HttpClient _httpClient;
        private readonly AppDbContext _dbContext;

        public AgeService(HttpClient httpClient, AppDbContext dbContext)
        {
            _httpClient = httpClient;
            _dbContext = dbContext;
        }

        public async Task<AgePrediction> GetAgePredictionAsync(string name)
        {
            var cachedPrediction = await _dbContext.AgePredictions.FindAsync(name);
            if (cachedPrediction != null)
            {
                return cachedPrediction;
            }
            var response = await _httpClient.GetFromJsonAsync<AgePrediction>($"?name={name}");

            if (response != null)
            {
                
                _dbContext.AgePredictions.Add(response);
                await _dbContext.SaveChangesAsync();
            }

            return response ?? new AgePrediction { Name = name, Age = 0, Count = 0 };
        }
    }
}
