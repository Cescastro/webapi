using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace webapi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    public class HelloWorldController: ControllerBase
    {
        IHelloWorldService helloWorldService;
        private readonly ILogger<HelloWorldController> _logger;
        
        public HelloWorldController(IHelloWorldService HelloWorld, 
                                    ILogger<HelloWorldController> logger)
        {
            helloWorldService = HelloWorld;
            _logger = logger;
        }

        [HttpGet] 
        public IActionResult Get()
        {
            _logger.LogInformation("retornado hello world");
            return Ok(helloWorldService.GetHelloWorld());
        }
    }

}