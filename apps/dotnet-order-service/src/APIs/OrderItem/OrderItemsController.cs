using Microsoft.AspNetCore.Mvc;

namespace DotnetOrderService.APIs;

[ApiController()]
public class OrderItemsController : OrderItemsControllerBase
{
    public OrderItemsController(IOrderItemsService service)
        : base(service) { }
}
