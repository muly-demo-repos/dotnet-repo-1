using Microsoft.AspNetCore.Mvc;

namespace FurnitureStoreService.APIs;

[ApiController()]
public class SuppliersController : SuppliersControllerBase
{
    public SuppliersController(ISuppliersService service)
        : base(service) { }
}
