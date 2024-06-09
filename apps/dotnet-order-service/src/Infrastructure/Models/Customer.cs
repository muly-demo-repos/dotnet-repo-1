using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetOrderService.Infrastructure.Models;

[Table("Customers")]
public class Customer
{
    [Required()]
    public DateTime CreatedAt { get; set; }

    public string? Email { get; set; }

    [StringLength(1000)]
    public string? FirstName { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [StringLength(1000)]
    public string? LastName { get; set; }

    public List<Order>? Orders { get; set; } = new List<Order>();

    [StringLength(1000)]
    public string? PhoneNumber { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
