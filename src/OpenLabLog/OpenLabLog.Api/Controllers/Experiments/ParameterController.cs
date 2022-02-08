using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenLabLog.Api.Controllers.Base;
using OpenLabLog.Core.Contracts.Services;
using OpenLabLog.Core.Models;

namespace OpenLabLog.Api.Controllers.Experiments
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParameterController : CrudBaseController<Parameter>
    {
        public ParameterController(IRepositoryService<Parameter> repositoryService, ILogger<CrudBaseController<Parameter>> logger) : base(repositoryService, logger)
        {
        }
    }
}
