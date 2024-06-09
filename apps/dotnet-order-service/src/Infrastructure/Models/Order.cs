using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DotnetOrderService.Core.Enums;

namespace DotnetOrderService.Infrastructure.Models;

[Table("Orders")]
public class Order
{
    [Required()]
    public DateTime CreatedAt { get; set; }

    public string? CustomerId { get; set; }

    [ForeignKey(nameof(CustomerId))]
    public Customer? Customer { get; set; } = null;

    [Key()]
    [Required()]
    public string Id { get; set; }

    public DateTime? OrderDate { get; set; }

    public List<OrderItem>? OrderItems { get; set; } = new List<OrderItem>();

    public List<Payment>? Payments { get; set; } = new List<Payment>();

    public StatusEnum? Status { get; set; }

    [Range(-999999999, 999999999)]
    public double? TotalAmount { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
