using Microsoft.AspNetCore.Mvc;
using Ntk2023.Api.Services;

namespace Ntk2023.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SqlTableController : ControllerBase
    {

        private readonly ILogger<SqlTableController> _logger;
        private readonly ISqlTableService _sqlTableService;

        public SqlTableController(ILogger<SqlTableController> logger, ISqlTableService sqlTableService)
        {
            _logger = logger;
            _sqlTableService = sqlTableService;
        }

        [HttpGet(Name = "GetTables")]
        public async Task <IEnumerable<SqlTable>> Get()
        {
            return await _sqlTableService.GeTables();
        }
    }
}