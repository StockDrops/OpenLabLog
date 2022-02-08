using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenLabLog.Api.Controllers.Base;
using OpenLabLog.Core.Contracts.Services;
using OpenLabLog.Core.Models;

namespace OpenLabLog.Api.Controllers.Experiments
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : CrudBaseController<Log>
    {
        public LogController(IRepositoryService<Log> repositoryService, ILogger<CrudBaseController<Log>> logger) : base(repositoryService, logger)
        {
        }
    }
}
