using DotnetOrderService.Core.Enums;

namespace DotnetOrderService.APIs.Dtos;

public class PaymentWhereInput
{
    public double? Amount { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? Id { get; set; }

    public MethodEnum? Method { get; set; }

    public OrderIdDto? Order { get; set; }

    public DateTime? PaymentDate { get; set; }

    public StatusEnum? Status { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
