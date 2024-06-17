using Microsoft.AspNetCore.Mvc;

namespace FurnitureStoreService.APIs;

[ApiController()]
public class OrdersController : OrdersControllerBase
{
    public OrdersController(IOrdersService service)
        : base(service) { }
}
