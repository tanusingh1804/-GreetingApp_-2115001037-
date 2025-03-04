using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModelLayer.Model;

namespace HelloGreetingApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloGreetingAppController : ControllerBase
    {
        private readonly ILogger<HelloGreetingAppController> _logger;

        public HelloGreetingAppController(ILogger<HelloGreetingAppController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("GET method called.");
            var responseModel = new ResponseModel<string>
            {
                Success = true,
                Message = "Hello to greeting API EndPoint",
                Data = "Hello, World!"
            };
            return Ok(responseModel);
        }

        [HttpPost]
        public IActionResult Post([FromBody] RequestModel requestModel)
        {
            _logger.LogInformation("POST method called with Key: {Key} and Value: {Value}", requestModel.Key, requestModel.Value);
            var responseModel = new ResponseModel<string>
            {
                Success = true,
                Message = "Request Received Successfully",
                Data = $"Key: {requestModel.Key}, Value: {requestModel.Value}"
            };
            return Ok(responseModel);
        }

        [HttpPut]
        public IActionResult Put([FromBody] RequestModel requestModel)
        {
            _logger.LogInformation("PUT method called with Key: {Key} and Value: {Value}", requestModel.Key, requestModel.Value);
            var responseModel = new ResponseModel<string>
            {
                Success = true,
                Message = "Request Updated Successfully",
                Data = $"Key: {requestModel.Key}, Value: {requestModel.Value}"
            };
            return Ok(responseModel);
        }

        [HttpPatch]
        public IActionResult Patch([FromBody] RequestModel requestModel)
        {
            _logger.LogInformation("PATCH method called with Key: {Key} and Value: {Value}", requestModel.Key, requestModel.Value);
            var responseModel = new ResponseModel<string>
            {
                Success = true,
                Message = "Request Updated Successfully",
                Data = $"Key: {requestModel.Key}, Value: {requestModel.Value}"
            };
            return Ok(responseModel);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] RequestModel requestModel)
        {
            _logger.LogInformation("DELETE method called with Key: {Key}", requestModel.Key);
            var responseModel = new ResponseModel<string>
            {
                Success = true,
                Message = "Request Deleted Successfully",
                Data = $"Deleted Key: {requestModel.Key}"
            };
            return Ok(responseModel);
        }
    }
}
