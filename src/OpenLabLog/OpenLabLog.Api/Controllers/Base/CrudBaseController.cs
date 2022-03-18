using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using OpenLabLog.Api.Contracts;
using OpenLabLog.Core.Contracts.Models;
using OpenLabLog.Core.Contracts.Services;
using OpenLabLog.Core.Models.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OpenLabLog.Api.Controllers.Base
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public abstract class CrudBaseController<T> : ControllerBase, ICrudController<T> where T : class, IEntity
    {
        protected IRepositoryService<T> _repositoryService;
        private readonly ILogger<CrudBaseController<T>> _logger;
        public CrudBaseController(IRepositoryService<T> repositoryService, ILogger<CrudBaseController<T>> logger)
        {
            _repositoryService = repositoryService;
            _logger = logger;
        }
        // GET: api/<ValuesController>
        /// <summary>
        /// Gets all the items of this kind.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
#if !DEBUG
        [RequiredScope(ApiScopes.Read)]
#endif
        public virtual Task<List<T>> GetAsync()
        {
            return _repositoryService.GetAllAsync();
        }
        /// <summary>
        /// Get an item with its id.
        /// </summary>
        /// <param name="id">long describing the id of the item.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
#if !DEBUG
        [RequiredScope(ApiScopes.Read)]
#endif
        public virtual Task<T?> GetAsync(long id)
        {
            return _repositoryService.GetAsync(id);
        }
        /// <summary>
        /// Save an item.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
#if !DEBUG
        [Authorize(Policy = PredifinedRoles.AdminsPolicyName)]   
        [RequiredScope(ApiScopes.Write)]
#endif
        public virtual async Task<ActionResult<T>> SaveAsync([FromBody] T entity)
        {
            try
            {
                await _repositoryService.CreateAsync(entity);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                //log
                _logger.LogError(ex, "");
                if (ex.InnerException != null)
                    return BadRequest(ex.InnerException.Message);
                return BadRequest(ex.Message);
            }

        }
        /// <summary>
        /// Deletes the item with the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        
        [HttpDelete("{id}")]
#if !DEBUG
        [Authorize(Policy = PredifinedRoles.AdminsPolicyName)]
        [RequiredScope(ApiScopes.Delete)]
#endif
        public virtual async Task<IActionResult> DeleteAsync(long id)
        {
            try
            {
                await _repositoryService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
                return BadRequest(ex);
            }
        }
        // PUT api/<ValuesController>/5
        /// <summary>
        /// Updates an item with a given id with the given json.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        
        [HttpPut("{id}")]
#if !DEBUG
        [Authorize(Policy = PredifinedRoles.AdminsPolicyName)]
        [RequiredScope(ApiScopes.Update)]
#endif
        public virtual async Task<IActionResult> UpdateAsync(long id, [FromBody] T entity)
        {
            if (entity == null)
                return BadRequest(new ArgumentNullException(nameof(entity)));
            if (id == 0)
                return BadRequest(new ArgumentException("id cannot be 0"));
            if (entity.Id != id)
                return BadRequest(new ArgumentException("id and entitie's id must be the same."));
            await _repositoryService.UpdateAsync(entity);
            return Ok();
        }
    }
}
