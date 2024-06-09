using Microsoft.AspNetCore.Mvc;

namespace DotnetOrderService.APIs;

[ApiController()]
public class OrdersController : OrdersControllerBase
{
    public OrdersController(IOrdersService service)
        : base(service) { }
}
