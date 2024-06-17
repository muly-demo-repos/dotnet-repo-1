using FurnitureStoreService.Infrastructure;

namespace FurnitureStoreService.APIs;

public class OrdersService : OrdersServiceBase
{
    public OrdersService(FurnitureStoreServiceDbContext context)
        : base(context) { }
}
