using FurnitureStoreService.Infrastructure;

namespace FurnitureStoreService.APIs;

public class OrderItemsService : OrderItemsServiceBase
{
    public OrderItemsService(FurnitureStoreServiceDbContext context)
        : base(context) { }
}
