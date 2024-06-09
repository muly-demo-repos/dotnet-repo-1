using DotnetOrderService.APIs;
using DotnetOrderService.APIs.Dtos;
using DotnetOrderService.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace DotnetOrderService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class ProductsControllerBase : ControllerBase
{
    protected readonly IProductsService _service;

    public ProductsControllerBase(IProductsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Product
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<ProductDto>> CreateProduct(ProductCreateInput input)
    {
        var product = await _service.CreateProduct(input);

        return CreatedAtAction(nameof(Product), new { id = product.Id }, product);
    }

    /// <summary>
    /// Delete one Product
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteProduct([FromRoute()] ProductIdDto idDto)
    {
        try
        {
            await _service.DeleteProduct(idDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Products
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<ProductDto>>> Products([FromQuery()] ProductFindMany filter)
    {
        return Ok(await _service.Products(filter));
    }

    /// <summary>
    /// Get one Product
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<ProductDto>> Product([FromRoute()] ProductIdDto idDto)
    {
        try
        {
            return await _service.Product(idDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Connect multiple OrderItems records to Product
    /// </summary>
    [HttpPost("{Id}/orderItems")]
    public async Task<ActionResult> ConnectOrderItems(
        [FromRoute()] ProductIdDto idDto,
        [FromQuery()] OrderItemIdDto[] orderItemsId
    )
    {
        try
        {
            await _service.ConnectOrderItems(idDto, orderItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple OrderItems records from Product
    /// </summary>
    [HttpDelete("{Id}/orderItems")]
    public async Task<ActionResult> DisconnectOrderItems(
        [FromRoute()] ProductIdDto idDto,
        [FromBody()] OrderItemIdDto[] orderItemsId
    )
    {
        try
        {
            await _service.DisconnectOrderItems(idDto, orderItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple OrderItems records for Product
    /// </summary>
    [HttpGet("{Id}/orderItems")]
    public async Task<ActionResult<List<OrderItemDto>>> FindOrderItems(
        [FromRoute()] ProductIdDto idDto,
        [FromQuery()] OrderItemFindMany filter
    )
    {
        try
        {
            return Ok(await _service.FindOrderItems(idDto, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple OrderItems records for Product
    /// </summary>
    [HttpPatch("{Id}/orderItems")]
    public async Task<ActionResult> UpdateOrderItems(
        [FromRoute()] ProductIdDto idDto,
        [FromBody()] OrderItemIdDto[] orderItemsId
    )
    {
        try
        {
            await _service.UpdateOrderItems(idDto, orderItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Update one Product
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateProduct(
        [FromRoute()] ProductIdDto idDto,
        [FromQuery()] ProductUpdateInput productUpdateDto
    )
    {
        try
        {
            await _service.UpdateProduct(idDto, productUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
