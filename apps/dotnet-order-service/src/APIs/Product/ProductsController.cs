using Microsoft.AspNetCore.Mvc;

namespace DotnetOrderService.APIs;

[ApiController()]
public class ProductsController : ProductsControllerBase
{
    public ProductsController(IProductsService service)
        : base(service) { }
}
