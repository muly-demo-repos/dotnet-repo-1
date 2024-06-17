namespace FurnitureStoreService.APIs.Dtos;

public class CategoryCreateInput
{
    public DateTime CreatedAt { get; set; }

    public string? Description { get; set; }

    public string? Id { get; set; }

    public string? Name { get; set; }

    public List<ProductIdDto>? Products { get; set; }

    public DateTime UpdatedAt { get; set; }
}
