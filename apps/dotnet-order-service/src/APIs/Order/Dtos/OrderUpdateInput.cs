using DotnetOrderService.Core.Enums;

namespace DotnetOrderService.APIs.Dtos;

public class OrderUpdateInput
{
    public DateTime? CreatedAt { get; set; }

    public CustomerIdDto? Customer { get; set; }

    public string? Id { get; set; }

    public DateTime? OrderDate { get; set; }

    public List<OrderItemIdDto>? OrderItems { get; set; }

    public List<PaymentIdDto>? Payments { get; set; }

    public StatusEnum? Status { get; set; }

    public double? TotalAmount { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
