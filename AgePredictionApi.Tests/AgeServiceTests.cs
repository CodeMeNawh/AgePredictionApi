using AgePredictionApi.Data;
using AgePredictionApi.Models;
using AgePredictionApi.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using RichardSzalay.MockHttp;
using System.Text.Json;

namespace AgePredictionApi.Tests
{
    [TestFixture]
    public class AgeServiceTests
{
    private AppDbContext _dbContext;
    private AgeService _ageService;
    private MockHttpMessageHandler _mockHttp;
    private HttpClient _httpClient;

    [SetUp]
    public void Setup()
    {
        
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;

        _dbContext = new AppDbContext(options);

        
        _mockHttp = new MockHttpMessageHandler();
        _httpClient = new HttpClient(_mockHttp)
        {
            BaseAddress = new Uri("https://api.agify.io/")
        };

       
        _ageService = new AgeService(_httpClient, _dbContext);
    }

    [Test]
    public async Task GetAgePredictionAsync_ReturnsCorrectData()
    {
        // Arrange
        var name = "Bob";
        var expectedResponse = new AgePrediction
        {
            Name = "Bob",
            Age = 20,
            Count = 20,
        };

        var jsonResponse = JsonSerializer.Serialize(expectedResponse);
        _mockHttp.When($"*?name={name}").Respond("application/json", jsonResponse);

        // Act
        var result = await _ageService.GetAgePredictionAsync(name);

        // Assert
        Assert.IsNotNull(result, "Result should not be null");
        Assert.AreEqual(expectedResponse.Name, result.Name, "Names should match");
        Assert.AreEqual(expectedResponse.Age, result.Age, "Ages should match");
        Assert.AreEqual(expectedResponse.Count, result.Count, "Counts should match");
    }
}
}
