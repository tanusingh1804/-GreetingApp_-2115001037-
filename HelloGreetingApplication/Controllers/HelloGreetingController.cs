using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BusinessLayer.Interface;
using ModelLayer.Model;
using BusinessLayer.Interface;

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

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("GET method called.");
            var greetingMessage = _greetingBL.GetGreeting(); // Calling Service Layer

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
