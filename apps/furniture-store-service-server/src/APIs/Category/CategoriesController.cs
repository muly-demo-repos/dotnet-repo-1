using Microsoft.AspNetCore.Mvc;

namespace FurnitureStoreService.APIs;

[ApiController()]
public class CategoriesController : CategoriesControllerBase
{
    public CategoriesController(ICategoriesService service)
        : base(service) { }
}
