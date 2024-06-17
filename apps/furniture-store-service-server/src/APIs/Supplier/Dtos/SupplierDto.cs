namespace FurnitureStoreService.APIs.Dtos;

public class SupplierDto : SupplierIdDto
{
    public string? Address { get; set; }

    public string? ContactPerson { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Email { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public DateTime UpdatedAt { get; set; }
}
