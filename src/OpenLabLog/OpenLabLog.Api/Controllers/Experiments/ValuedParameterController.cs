using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenLabLog.Api.Controllers.Base;
using OpenLabLog.Core.Contracts.Services;
using OpenLabLog.Core.Models;

namespace OpenLabLog.Api.Controllers.Experiments
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuedParameterController : CrudBaseController<ValuedParameter>
    {
        public ValuedParameterController(IRepositoryService<ValuedParameter> repositoryService, ILogger<CrudBaseController<ValuedParameter>> logger) : base(repositoryService, logger)
        {
        }
    }
}
