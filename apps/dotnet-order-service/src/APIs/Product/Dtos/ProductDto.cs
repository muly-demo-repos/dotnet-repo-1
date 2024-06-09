namespace DotnetOrderService.APIs.Dtos;

public class ProductDto : ProductIdDto
{
    public DateTime CreatedAt { get; set; }

    public string? Description { get; set; }

    public string? Name { get; set; }

    public List<OrderItemIdDto>? OrderItems { get; set; }

    public double? Price { get; set; }

    public int? StockQuantity { get; set; }

    public DateTime UpdatedAt { get; set; }
}
