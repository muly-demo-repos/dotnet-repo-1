using Microsoft.AspNetCore.Mvc;

namespace DotnetOrderService.APIs;

[ApiController()]
public class CustomersController : CustomersControllerBase
{
    public CustomersController(ICustomersService service)
        : base(service) { }
}
