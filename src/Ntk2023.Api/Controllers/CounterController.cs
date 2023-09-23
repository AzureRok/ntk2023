using Dapr.Client;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using Ntk2023.Api.Services;
using System.Security.Cryptography.X509Certificates;

namespace Ntk2023.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CounterController : ControllerBase
    {
        const string storeName = "statestore";
        const string key = "counter";

        private readonly ILogger<CounterController> _logger;
        private readonly DaprClient _daprClient;

        public CounterController(ILogger<CounterController> logger, DaprClient daprClient)
        {
            _logger = logger;
            _daprClient = daprClient;
        }

        [HttpPost(Name = "GetAndIncrementCounter")]
        public async Task<int> Get()
        {
            var counter = await _daprClient.GetStateAsync<int>(storeName, key);
            await _daprClient.SaveStateAsync(storeName, key, ++counter);
            return counter;
        }
    }
}
