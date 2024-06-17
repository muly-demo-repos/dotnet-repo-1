using FurnitureStoreService.Infrastructure;

namespace FurnitureStoreService.APIs;

public class ProductsService : ProductsServiceBase
{
    public ProductsService(FurnitureStoreServiceDbContext context)
        : base(context) { }
}
