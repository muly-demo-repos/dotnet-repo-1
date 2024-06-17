using Microsoft.AspNetCore.Mvc;

namespace FurnitureStoreService.APIs;

[ApiController()]
public class CustomersController : CustomersControllerBase
{
    public CustomersController(ICustomersService service)
        : base(service) { }
}
