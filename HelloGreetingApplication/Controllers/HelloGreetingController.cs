using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BusinessLayer.Interface;
using ModelLayer.Model;
using RepositoryLayer.Entity;
using RepositoryLayer.Context;

namespace HelloGreetingApp.Controllers
{
    [ApiController]
    [Route("HelloGreeting")]
    public class HelloGreetingAppController : ControllerBase
    {
        private readonly ILogger<HelloGreetingAppController> _logger;
        private readonly IGreetingBL _greetingBL;
        private readonly GreetingContext  _context;

        public HelloGreetingAppController(ILogger<HelloGreetingAppController> logger, IGreetingBL greetingBL, GreetingContext context)
        {  
            _logger = logger;
            _greetingBL = greetingBL;
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet]
        public IActionResult GetGreeting([FromQuery] string? firstName, [FromQuery] string? lastName)
        {
            _logger.LogInformation("GET method called.");
            var greetingMessage = _greetingBL.GetGreeting(firstName, lastName);

            var responseModel = new ResponseModel<string>
            {
                Success = true,
                Message = "Greeting Message Retrieved",
                Data = greetingMessage
            };
            return Ok(responseModel);
        }

        [HttpPost("SaveGreeting")]
        public IActionResult SaveGreeting([FromBody] GreetingEntity greeting)
        {
            if (string.IsNullOrEmpty(greeting.Message))
            {
                return BadRequest(new ResponseModel<string>
                {
                    Success = false,
                    Message = "Greeting message cannot be empty",
                    Data = null
                });
            }

            _greetingBL.SaveGreeting(greeting.Message);

            return Ok(new ResponseModel<string>
            {
                Success = true,
                Message = "Greeting Saved Successfully",
                Data = greeting.Message
            });
        }

        //[HttpGet("AllGreetings")]
        //public IActionResult GetAllGreetings()
        //{
        //    var greetings = _greetingBL.GetAllGreetings();
        //    return Ok(new ResponseModel<List<string>>
        //    {
        //        Success = true,
        //        Message = "All Greetings Retrieved",
        //        Data = greetings
        //    });
        }
    }
