using Microsoft.AspNetCore.Mvc;
using Service;

namespace WebAPI.Controllers
{
    [ApiController]
    public class AddressController : CRUDController<AddressDTO>
    {
        public AddressController(IAddressService AddressService) : base(AddressService) { }
    }
}