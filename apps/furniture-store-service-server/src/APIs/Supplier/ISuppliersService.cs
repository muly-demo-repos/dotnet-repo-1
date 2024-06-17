using FurnitureStoreService.APIs.Common;
using FurnitureStoreService.APIs.Dtos;

namespace FurnitureStoreService.APIs;

public interface ISuppliersService
{
    /// <summary>
    /// Create one Supplier
    /// </summary>
    public Task<SupplierDto> CreateSupplier(SupplierCreateInput supplierDto);

    /// <summary>
    /// Delete one Supplier
    /// </summary>
    public Task DeleteSupplier(SupplierIdDto idDto);

    /// <summary>
    /// Find many Suppliers
    /// </summary>
    public Task<List<SupplierDto>> Suppliers(SupplierFindMany findManyArgs);

    /// <summary>
    /// Get one Supplier
    /// </summary>
    public Task<SupplierDto> Supplier(SupplierIdDto idDto);

    /// <summary>
    /// Meta data about Supplier records
    /// </summary>
    public Task<MetadataDto> SuppliersMeta(SupplierFindMany findManyArgs);

    /// <summary>
    /// Update one Supplier
    /// </summary>
    public Task UpdateSupplier(SupplierIdDto idDto, SupplierUpdateInput updateDto);
}
