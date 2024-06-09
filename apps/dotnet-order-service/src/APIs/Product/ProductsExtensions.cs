using DotnetOrderService.APIs.Dtos;
using DotnetOrderService.Infrastructure.Models;

namespace DotnetOrderService.APIs.Extensions;

public static class ProductsExtensions
{
    public static ProductDto ToDto(this Product model)
    {
        return new ProductDto
        {
            CreatedAt = model.CreatedAt,
            Description = model.Description,
            Id = model.Id,
            Name = model.Name,
            OrderItems = model.OrderItems?.Select(x => new OrderItemIdDto { Id = x.Id }).ToList(),
            Price = model.Price,
            StockQuantity = model.StockQuantity,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static Product ToModel(this ProductUpdateInput updateDto, ProductIdDto idDto)
    {
        var product = new Product
        {
            Id = idDto.Id,
            Description = updateDto.Description,
            Name = updateDto.Name,
            Price = updateDto.Price,
            StockQuantity = updateDto.StockQuantity
        };

        // map required fields
        if (updateDto.CreatedAt != null)
        {
            product.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            product.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return product;
    }
}
