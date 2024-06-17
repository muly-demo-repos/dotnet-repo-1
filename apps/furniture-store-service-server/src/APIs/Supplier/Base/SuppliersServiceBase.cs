using FurnitureStoreService.APIs;
using FurnitureStoreService.APIs.Common;
using FurnitureStoreService.APIs.Dtos;
using FurnitureStoreService.APIs.Errors;
using FurnitureStoreService.APIs.Extensions;
using FurnitureStoreService.Infrastructure;
using FurnitureStoreService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace FurnitureStoreService.APIs;

public abstract class SuppliersServiceBase : ISuppliersService
{
    protected readonly FurnitureStoreServiceDbContext _context;

    public SuppliersServiceBase(FurnitureStoreServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Supplier
    /// </summary>
    public async Task<SupplierDto> CreateSupplier(SupplierCreateInput createDto)
    {
        var supplier = new Supplier
        {
            Address = createDto.Address,
            ContactPerson = createDto.ContactPerson,
            CreatedAt = createDto.CreatedAt,
            Email = createDto.Email,
            Name = createDto.Name,
            Phone = createDto.Phone,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            supplier.Id = createDto.Id;
        }

        _context.Suppliers.Add(supplier);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<Supplier>(supplier.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Supplier
    /// </summary>
    public async Task DeleteSupplier(SupplierIdDto idDto)
    {
        var supplier = await _context.Suppliers.FindAsync(idDto.Id);
        if (supplier == null)
        {
            throw new NotFoundException();
        }

        _context.Suppliers.Remove(supplier);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Suppliers
    /// </summary>
    public async Task<List<SupplierDto>> Suppliers(SupplierFindMany findManyArgs)
    {
        var suppliers = await _context
            .Suppliers.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return suppliers.ConvertAll(supplier => supplier.ToDto());
    }

    /// <summary>
    /// Get one Supplier
    /// </summary>
    public async Task<SupplierDto> Supplier(SupplierIdDto idDto)
    {
        var suppliers = await this.Suppliers(
            new SupplierFindMany { Where = new SupplierWhereInput { Id = idDto.Id } }
        );
        var supplier = suppliers.FirstOrDefault();
        if (supplier == null)
        {
            throw new NotFoundException();
        }

        return supplier;
    }

    /// <summary>
    /// Meta data about Supplier records
    /// </summary>
    public async Task<MetadataDto> SuppliersMeta(SupplierFindMany findManyArgs)
    {
        var count = await _context.Suppliers.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Update one Supplier
    /// </summary>
    public async Task UpdateSupplier(SupplierIdDto idDto, SupplierUpdateInput updateDto)
    {
        var supplier = updateDto.ToModel(idDto);

        _context.Entry(supplier).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Suppliers.Any(e => e.Id == supplier.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}
