using DotnetOrderService.APIs;
using DotnetOrderService.APIs.Common;
using DotnetOrderService.APIs.Dtos;
using DotnetOrderService.APIs.Errors;
using DotnetOrderService.APIs.Extensions;
using DotnetOrderService.Infrastructure;
using DotnetOrderService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetOrderService.APIs;

public abstract class ProductsServiceBase : IProductsService
{
    protected readonly DotnetOrderServiceDbContext _context;

    public ProductsServiceBase(DotnetOrderServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Product
    /// </summary>
    public async Task<ProductDto> CreateProduct(ProductCreateInput createDto)
    {
        var product = new Product
        {
            CreatedAt = createDto.CreatedAt,
            Description = createDto.Description,
            Name = createDto.Name,
            Price = createDto.Price,
            StockQuantity = createDto.StockQuantity,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            product.Id = createDto.Id;
        }
        if (createDto.OrderItems != null)
        {
            product.OrderItems = await _context
                .OrderItems.Where(orderItem =>
                    createDto.OrderItems.Select(t => t.Id).Contains(orderItem.Id)
                )
                .ToListAsync();
        }

        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<Product>(product.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Product
    /// </summary>
    public async Task DeleteProduct(ProductIdDto idDto)
    {
        var product = await _context.Products.FindAsync(idDto.Id);
        if (product == null)
        {
            throw new NotFoundException();
        }

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Products
    /// </summary>
    public async Task<List<ProductDto>> Products(ProductFindMany findManyArgs)
    {
        var products = await _context
            .Products.Include(x => x.OrderItems)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return products.ConvertAll(product => product.ToDto());
    }

    /// <summary>
    /// Get one Product
    /// </summary>
    public async Task<ProductDto> Product(ProductIdDto idDto)
    {
        var products = await this.Products(
            new ProductFindMany { Where = new ProductWhereInput { Id = idDto.Id } }
        );
        var product = products.FirstOrDefault();
        if (product == null)
        {
            throw new NotFoundException();
        }

        return product;
    }

    /// <summary>
    /// Connect multiple OrderItems records to Product
    /// </summary>
    public async Task ConnectOrderItems(ProductIdDto idDto, OrderItemIdDto[] orderItemsId)
    {
        var product = await _context
            .Products.Include(x => x.OrderItems)
            .FirstOrDefaultAsync(x => x.Id == idDto.Id);
        if (product == null)
        {
            throw new NotFoundException();
        }

        var orderItems = await _context
            .OrderItems.Where(t => orderItemsId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (orderItems.Count == 0)
        {
            throw new NotFoundException();
        }

        var orderItemsToConnect = orderItems.Except(product.OrderItems);

        foreach (var orderItem in orderItemsToConnect)
        {
            product.OrderItems.Add(orderItem);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple OrderItems records from Product
    /// </summary>
    public async Task DisconnectOrderItems(ProductIdDto idDto, OrderItemIdDto[] orderItemsId)
    {
        var product = await _context
            .Products.Include(x => x.OrderItems)
            .FirstOrDefaultAsync(x => x.Id == idDto.Id);
        if (product == null)
        {
            throw new NotFoundException();
        }

        var orderItems = await _context
            .OrderItems.Where(t => orderItemsId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var orderItem in orderItems)
        {
            product.OrderItems?.Remove(orderItem);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple OrderItems records for Product
    /// </summary>
    public async Task<List<OrderItemDto>> FindOrderItems(
        ProductIdDto idDto,
        OrderItemFindMany productFindMany
    )
    {
        var orderItems = await _context
            .OrderItems.Where(m => m.ProductId == idDto.Id)
            .ApplyWhere(productFindMany.Where)
            .ApplySkip(productFindMany.Skip)
            .ApplyTake(productFindMany.Take)
            .ApplyOrderBy(productFindMany.SortBy)
            .ToListAsync();

        return orderItems.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple OrderItems records for Product
    /// </summary>
    public async Task UpdateOrderItems(ProductIdDto idDto, OrderItemIdDto[] orderItemsId)
    {
        var product = await _context
            .Products.Include(t => t.OrderItems)
            .FirstOrDefaultAsync(x => x.Id == idDto.Id);
        if (product == null)
        {
            throw new NotFoundException();
        }

        var orderItems = await _context
            .OrderItems.Where(a => orderItemsId.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (orderItems.Count == 0)
        {
            throw new NotFoundException();
        }

        product.OrderItems = orderItems;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Update one Product
    /// </summary>
    public async Task UpdateProduct(ProductIdDto idDto, ProductUpdateInput updateDto)
    {
        var product = updateDto.ToModel(idDto);

        if (updateDto.OrderItems != null)
        {
            product.OrderItems = await _context
                .OrderItems.Where(orderItem =>
                    updateDto.OrderItems.Select(t => t.Id).Contains(orderItem.Id)
                )
                .ToListAsync();
        }

        _context.Entry(product).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Products.Any(e => e.Id == product.Id))
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
