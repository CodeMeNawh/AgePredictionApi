using AgePredictionApi.Interfaces;
using AgePredictionApi.Services;

namespace AgePredictionApi.Extensions
{
    public static class ServiceExtension
    {
        public static void AddAgeService(this IServiceCollection services)
        {
            services.AddHttpClient<IAgeService, AgeService>(client =>
            {
                client.BaseAddress = new Uri("https://api.agify.io/");
            });
        }
    }
}
