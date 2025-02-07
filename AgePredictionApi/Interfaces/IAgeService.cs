using AgePredictionApi.Models;

namespace AgePredictionApi.Interfaces
{
    public interface IAgeService
    {
        Task<AgePrediction>GetAgePredictionAsync(string name);
    }
}
