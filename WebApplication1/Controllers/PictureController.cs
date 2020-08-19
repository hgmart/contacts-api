using Microsoft.AspNetCore.Mvc;
using Service;
using System;

namespace WebAPI.Controllers
{
    [ApiController]
    public class PictureController : CRUDController<PictureDTO>
    {
        public PictureController(IPictureService pictureService) : base(pictureService) { }

        [HttpGet]
        [Route("[controller]/{Guid}")]
        public override ActionResult Read([FromRoute] Guid guid)
        {
            return ServiceInvocationResult(() => {
                var pictureBase64 = ServiceController.Read(guid).PictureBase64;
                var bytes = Convert.FromBase64String(pictureBase64);
                return new FileContentResult(bytes, "image/jpg");
                });
        }
    }
}