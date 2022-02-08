using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenLabLog.Api.Controllers.Base;
using OpenLabLog.Core.Contracts.Services;
using OpenLabLog.Core.Models;

namespace OpenLabLog.Api.Controllers.Experiments
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogBookController : CrudBaseController<LogBook>
    {
        public LogBookController(IRepositoryService<LogBook> repositoryService, ILogger<CrudBaseController<LogBook>> logger) : base(repositoryService, logger)
        {
        }
    }
}
