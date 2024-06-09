using DotnetOrderService.Infrastructure;

namespace DotnetOrderService.APIs;

public class PaymentsService : PaymentsServiceBase
{
    public PaymentsService(DotnetOrderServiceDbContext context)
        : base(context) { }
}
