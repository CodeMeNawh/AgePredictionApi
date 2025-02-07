using AgePredictionApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AgePredictionApi.Controllers
{
    [ApiController]
    [Route("Age")]
    public class AgeController : ControllerBase
    {
        private readonly IAgeService _ageService;

        public AgeController(IAgeService ageService)
        {
            _ageService = ageService;
        }

        [HttpGet("name")]

        public async Task<IActionResult>GetAge(string name) 
        {
            var prediction = await _ageService.GetAgePredictionAsync(name);

            return Ok(prediction);
        }
    }
}
