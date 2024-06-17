using FurnitureStoreService.Infrastructure;

namespace FurnitureStoreService.APIs;

public class CategoriesService : CategoriesServiceBase
{
    public CategoriesService(FurnitureStoreServiceDbContext context)
        : base(context) { }
}
