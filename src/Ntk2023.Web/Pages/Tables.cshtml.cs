using Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ntk2023.Web.Pages
{
    public class TablesModel : PageModel
    {
        private readonly ILogger<TablesModel> _logger;
        private readonly IApiClient _apiClient;

        public IEnumerable<SqlTable> Tables { get; private set; }

        public TablesModel(ILogger<TablesModel> logger, IApiClient apiClient)
        {
            _logger = logger;
            _apiClient = apiClient;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            this.Tables = await this._apiClient.GetTablesAsync();
            return Page();
        }
    }
}
