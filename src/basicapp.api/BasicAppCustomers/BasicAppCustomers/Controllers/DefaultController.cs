using System;
using System.Collections.Generic;
using BasicAppCustomers.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BasicAppCustomers.Controllers
{
    [ApiController]
    [Route("/api/")]
    public class DefaultController : ControllerBase
    {
        private readonly CustomersDatabaseService _service;
        
        private readonly ILogger<DefaultController> _logger;

        public DefaultController(ILogger<DefaultController> logger, CustomersDatabaseService query)
        {
            _logger = logger;
            _service = query;
        }

        [Route("healthStatus")]
        [HttpGet]
        public ApiStatusReport GetHealthStatus()
        {
            return new ApiStatusReport()
            {
                Status = "API Backend is running successfully.",
                Timestamp = DateTime.Now
            };
        }

        [Route("buildDatabase")]
        [HttpPost]
        public ApiStatusReport BuildDatabase()
        {
            _service.BuildDatabase();
            return new ApiStatusReport()
            {
                Status = "Successfully Created Database.",
                Timestamp = DateTime.Now
            };
        }

        [Route("loadCustomers")]
        [HttpGet]
        public IEnumerable<CustomerViewModel> LoadCustomers()
        {
            return _service.GetAllCustomers();
        }
    }
}