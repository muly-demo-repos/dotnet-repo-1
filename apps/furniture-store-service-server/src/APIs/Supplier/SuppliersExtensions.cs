using FurnitureStoreService.APIs.Dtos;
using FurnitureStoreService.Infrastructure.Models;

namespace FurnitureStoreService.APIs.Extensions;

public static class SuppliersExtensions
{
    public static SupplierDto ToDto(this Supplier model)
    {
        return new SupplierDto
        {
            Address = model.Address,
            ContactPerson = model.ContactPerson,
            CreatedAt = model.CreatedAt,
            Email = model.Email,
            Id = model.Id,
            Name = model.Name,
            Phone = model.Phone,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static Supplier ToModel(this SupplierUpdateInput updateDto, SupplierIdDto idDto)
    {
        var supplier = new Supplier
        {
            Id = idDto.Id,
            Address = updateDto.Address,
            ContactPerson = updateDto.ContactPerson,
            Email = updateDto.Email,
            Name = updateDto.Name,
            Phone = updateDto.Phone
        };

        // map required fields
        if (updateDto.CreatedAt != null)
        {
            supplier.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            supplier.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return supplier;
    }
}
