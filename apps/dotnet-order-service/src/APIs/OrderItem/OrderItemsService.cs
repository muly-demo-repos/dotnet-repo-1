using DotnetOrderService.Infrastructure;

namespace DotnetOrderService.APIs;

public class OrderItemsService : OrderItemsServiceBase
{
    public OrderItemsService(DotnetOrderServiceDbContext context)
        : base(context) { }
}
