using DotnetOrderService.Infrastructure;

namespace DotnetOrderService.APIs;

public class OrdersService : OrdersServiceBase
{
    public OrdersService(DotnetOrderServiceDbContext context)
        : base(context) { }
}
