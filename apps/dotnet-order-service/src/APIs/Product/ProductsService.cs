using DotnetOrderService.Infrastructure;

namespace DotnetOrderService.APIs;

public class ProductsService : ProductsServiceBase
{
    public ProductsService(DotnetOrderServiceDbContext context)
        : base(context) { }
}
