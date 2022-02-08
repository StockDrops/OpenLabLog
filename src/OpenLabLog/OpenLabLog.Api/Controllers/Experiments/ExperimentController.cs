using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenLabLog.Api.Controllers.Base;
using OpenLabLog.Core.Contracts.Services;
using OpenLabLog.Core.Models;

namespace OpenLabLog.Api.Controllers.Experiments
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperimentController : CrudBaseController<Experiment>
    {
        public ExperimentController(IRepositoryService<Experiment> repositoryService, ILogger<CrudBaseController<Experiment>> logger) : base(repositoryService, logger)
        {
        }
    }
}
