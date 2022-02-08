using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenLabLog.Api.Controllers.Base;
using OpenLabLog.Core.Contracts.Services;
using OpenLabLog.Core.Models;

namespace OpenLabLog.Api.Controllers.Experiments
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogEntryController : CrudBaseController<LogEntry>
    {
        public LogEntryController(IRepositoryService<LogEntry> repositoryService, ILogger<CrudBaseController<LogEntry>> logger) : base(repositoryService, logger)
        {
        }
    }
}
