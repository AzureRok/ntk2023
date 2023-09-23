using Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ntk2023.Web.Pages
{
    public class CounterModel : PageModel
    {
        private readonly ILogger<CounterModel> _logger;
        private readonly IApiClient _apiClient;

        public int CurrentCount { get; private set; }

        public CounterModel(ILogger<CounterModel> logger, IApiClient apiClient)
        {
            _logger = logger;
            _apiClient = apiClient;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            this.CurrentCount = await this._apiClient.GetAndIncrementCounterAsync();
            return Page();
        }

        public async Task OnPostIncrementAsync()
        {
            this.CurrentCount = await this._apiClient.GetAndIncrementCounterAsync();
        }
    }
}
