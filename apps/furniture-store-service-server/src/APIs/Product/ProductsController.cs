using Microsoft.AspNetCore.Mvc;

namespace FurnitureStoreService.APIs;

[ApiController()]
public class ProductsController : ProductsControllerBase
{
    public ProductsController(IProductsService service)
        : base(service) { }
}
