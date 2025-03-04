using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BusinessLayer.Interface;
using ModelLayer.Model;

namespace HelloGreetingApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloGreetingAppController : ControllerBase
    {
        private readonly ILogger<HelloGreetingAppController> _logger;
        private readonly IGreetingBL _greetingBL;

        public HelloGreetingAppController(ILogger<HelloGreetingAppController> logger, IGreetingBL greetingBL)
        {
            _logger = logger;
            _greetingBL = greetingBL;
        }

        [HttpGet("greet")]
        public IActionResult GetGreeting([FromQuery] string? firstName, [FromQuery] string? lastName)
        {
            _logger.LogInformation("GET Greeting method called with FirstName: {FirstName}, LastName: {LastName}", firstName, lastName);
            var greetingMessage = _greetingBL.GetGreeting(firstName, lastName);

            var responseModel = new ResponseModel<string>
            {
                Success = true,
                Message = "Greeting Message Retrieved",
                Data = greetingMessage
            };
            return Ok(responseModel);
        }
    }
}
