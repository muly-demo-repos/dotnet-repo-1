using FurnitureStoreService.APIs;
using FurnitureStoreService.APIs.Common;
using FurnitureStoreService.APIs.Dtos;
using FurnitureStoreService.APIs.Errors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureStoreService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class SuppliersControllerBase : ControllerBase
{
    protected readonly ISuppliersService _service;

    public SuppliersControllerBase(ISuppliersService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Supplier
    /// </summary>
    [HttpPost()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<SupplierDto>> CreateSupplier(SupplierCreateInput input)
    {
        var supplier = await _service.CreateSupplier(input);

        return CreatedAtAction(nameof(Supplier), new { id = supplier.Id }, supplier);
    }

    /// <summary>
    /// Delete one Supplier
    /// </summary>
    [HttpDelete("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> DeleteSupplier([FromRoute()] SupplierIdDto idDto)
    {
        try
        {
            await _service.DeleteSupplier(idDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Suppliers
    /// </summary>
    [HttpGet()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<List<SupplierDto>>> Suppliers(
        [FromQuery()] SupplierFindMany filter
    )
    {
        return Ok(await _service.Suppliers(filter));
    }

    /// <summary>
    /// Get one Supplier
    /// </summary>
    [HttpGet("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<SupplierDto>> Supplier([FromRoute()] SupplierIdDto idDto)
    {
        try
        {
            return await _service.Supplier(idDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Meta data about Supplier records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> SuppliersMeta(
        [FromQuery()] SupplierFindMany filter
    )
    {
        return Ok(await _service.SuppliersMeta(filter));
    }

    /// <summary>
    /// Update one Supplier
    /// </summary>
    [HttpPatch("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> UpdateSupplier(
        [FromRoute()] SupplierIdDto idDto,
        [FromQuery()] SupplierUpdateInput supplierUpdateDto
    )
    {
        try
        {
            await _service.UpdateSupplier(idDto, supplierUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
