using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetOrderService.Infrastructure.Models;

[Table("Products")]
public class Product
{
    [Required()]
    public DateTime CreatedAt { get; set; }

    [StringLength(1000)]
    public string? Description { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [StringLength(1000)]
    public string? Name { get; set; }

    public List<OrderItem>? OrderItems { get; set; } = new List<OrderItem>();

    [Range(-999999999, 999999999)]
    public double? Price { get; set; }

    [Range(-999999999, 999999999)]
    public int? StockQuantity { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
