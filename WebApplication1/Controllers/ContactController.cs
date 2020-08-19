using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using System;

namespace WebAPI.Controllers
{
    [ApiController]
    public class ContactController : CRUDController<ContactDTO>
    {
        private readonly IContactService ContactService;

        public ContactController(IContactService contactService) : base(contactService) 
        {
            ContactService = contactService;
        }

        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [Route("[controller]/[action]")]
        public ActionResult Search([FromBody]FilterContactDTO filterDTO)
        {
            return ServiceInvocationResult(() => new OkObjectResult(ContactService.Search(filterDTO)));
        }

    }
}