using FurnitureStoreService.Infrastructure;

namespace FurnitureStoreService.APIs;

public class CustomersService : CustomersServiceBase
{
    public CustomersService(FurnitureStoreServiceDbContext context)
        : base(context) { }
}
