using FurnitureStoreService.APIs.Dtos;
using FurnitureStoreService.Infrastructure.Models;

namespace FurnitureStoreService.APIs.Extensions;

public static class CategoriesExtensions
{
    public static CategoryDto ToDto(this Category model)
    {
        return new CategoryDto
        {
            CreatedAt = model.CreatedAt,
            Description = model.Description,
            Id = model.Id,
            Name = model.Name,
            Products = model.Products?.Select(x => new ProductIdDto { Id = x.Id }).ToList(),
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static Category ToModel(this CategoryUpdateInput updateDto, CategoryIdDto idDto)
    {
        var category = new Category
        {
            Id = idDto.Id,
            Description = updateDto.Description,
            Name = updateDto.Name
        };

        // map required fields
        if (updateDto.CreatedAt != null)
        {
            category.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            category.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return category;
    }
}
