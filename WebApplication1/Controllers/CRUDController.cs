using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using System;

namespace WebAPI.Controllers
{
    public abstract class CRUDController<EntityDTO> : Controller where EntityDTO : class
    {
        protected readonly ICRUDService<EntityDTO> ServiceController;

        public CRUDController(ICRUDService<EntityDTO> crudService)
        {
            ServiceController = crudService;
        }

        [HttpPost]
        [Consumes("application/json")]
        [Route("[controller]")]
        public virtual ActionResult Create([FromBody] EntityDTO entityDTO)
        {
            return ServiceInvocationResult(() => new OkObjectResult(ServiceController.Create(entityDTO)));
        }

        [HttpGet]
        [Produces("application/json")]
        [Route("[controller]/{Guid}")]
        public virtual ActionResult Read([FromRoute]Guid guid)
        {
            return ServiceInvocationResult(() => new OkObjectResult(ServiceController.Read(guid)));
        }

        [HttpPut]
        [Consumes("application/json")]
        [Route("[controller]/{Guid}")]
        public virtual ActionResult Update([FromRoute]Guid guid, [FromBody] EntityDTO entityDTO)
        {
            return ServiceInvocationResult(() =>
            {
                ServiceController.Update(entityDTO);
                return new StatusCodeResult(StatusCodes.Status204NoContent);
            });
        }

        [HttpDelete]
        [Produces("application/json")]
        [Route("[controller]/{Guid}")]
        public virtual ActionResult Delete([FromRoute]Guid guid)
        {
            return ServiceInvocationResult(() => ServiceController.Delete(guid) ? new StatusCodeResult(StatusCodes.Status204NoContent) : NotFound());
        }

        protected virtual ActionResult ServiceInvocationResult(Func<ActionResult> accion)
        {
            try
            {
                return accion();
            }

            catch (ParameterException pe)
            {
                return BadRequest(pe.Message);
            }

            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }

        }
    }
}
