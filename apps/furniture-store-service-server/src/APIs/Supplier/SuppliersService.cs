using FurnitureStoreService.Infrastructure;

namespace FurnitureStoreService.APIs;

public class SuppliersService : SuppliersServiceBase
{
    public SuppliersService(FurnitureStoreServiceDbContext context)
        : base(context) { }
}
