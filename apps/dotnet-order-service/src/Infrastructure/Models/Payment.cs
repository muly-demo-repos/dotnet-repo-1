using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DotnetOrderService.Core.Enums;

namespace DotnetOrderService.Infrastructure.Models;

[Table("Payments")]
public class Payment
{
    [Range(-999999999, 999999999)]
    public double? Amount { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    public MethodEnum? Method { get; set; }

    public string? OrderId { get; set; }

    [ForeignKey(nameof(OrderId))]
    public Order? Order { get; set; } = null;

    public DateTime? PaymentDate { get; set; }

    public StatusEnum? Status { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
