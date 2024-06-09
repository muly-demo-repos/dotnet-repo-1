using DotnetOrderService.APIs;

namespace DotnetOrderService;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<ICustomersService, CustomersService>();
        services.AddScoped<IOrdersService, OrdersService>();
        services.AddScoped<IOrderItemsService, OrderItemsService>();
        services.AddScoped<IPaymentsService, PaymentsService>();
        services.AddScoped<IProductsService, ProductsService>();
    }
}
