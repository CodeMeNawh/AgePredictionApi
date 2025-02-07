using AgePredictionApi.Models;
using AgePredictionApi.Services;
using NUnit.Framework;
using RichardSzalay.MockHttp;
using System.Text.Json;


namespace AgePredictionApi.Tests
{
    [TestFixture]
    public class AgeServiceTests
    {
        [Test]
        public async Task GetAgePredictionAsync_ReturnsCorrectData()
        {
            //Arrange

            var name = "Bob";

            var expectedResponse = new AgePrediction
            {
                Name = "Bob",
                Age = 20,
                Count = 20,
            };

            var jsonResponse = JsonSerializer.Serialize(expectedResponse);

            var mockHttp = new MockHttpMessageHandler();

            mockHttp.When($"*?name={name}").Respond("application/json",jsonResponse);

            var httpClient = new HttpClient(mockHttp)
            {
                BaseAddress = new Uri("https://api.agify.io/")
            };

            var ageService = new AgeService(httpClient);

            //Act

            var result = await ageService.GetAgePredictionAsync(name);

            //Assert 

           Assert.IsNotNull(result);
           Assert.AreEqual(expectedResponse.Name, result.Name);
           Assert.AreEqual(expectedResponse.Age, result.Age);
           Assert.AreEqual(expectedResponse.Count, result.Count);
          
        }

    }
}
