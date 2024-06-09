namespace DotnetOrderService.APIs.Dtos;

public class CustomerWhereInput
{
    public DateTime? CreatedAt { get; set; }

    public string? Email { get; set; }

    public string? FirstName { get; set; }

    public string? Id { get; set; }

    public string? LastName { get; set; }

    public List<OrderIdDto>? Orders { get; set; }

    public string? PhoneNumber { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
