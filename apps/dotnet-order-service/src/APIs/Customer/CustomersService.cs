using DotnetOrderService.Infrastructure;

namespace DotnetOrderService.APIs;

public class CustomersService : CustomersServiceBase
{
    public CustomersService(DotnetOrderServiceDbContext context)
        : base(context) { }
}
