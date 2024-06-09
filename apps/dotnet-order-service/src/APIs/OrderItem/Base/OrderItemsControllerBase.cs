using DotnetOrderService.APIs;
using DotnetOrderService.APIs.Dtos;
using DotnetOrderService.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace DotnetOrderService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class OrderItemsControllerBase : ControllerBase
{
    protected readonly IOrderItemsService _service;

    public OrderItemsControllerBase(IOrderItemsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one OrderItem
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<OrderItemDto>> CreateOrderItem(OrderItemCreateInput input)
    {
        var orderItem = await _service.CreateOrderItem(input);

        return CreatedAtAction(nameof(OrderItem), new { id = orderItem.Id }, orderItem);
    }

    /// <summary>
    /// Delete one OrderItem
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteOrderItem([FromRoute()] OrderItemIdDto idDto)
    {
        try
        {
            await _service.DeleteOrderItem(idDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many OrderItems
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<OrderItemDto>>> OrderItems(
        [FromQuery()] OrderItemFindMany filter
    )
    {
        return Ok(await _service.OrderItems(filter));
    }

    /// <summary>
    /// Get one OrderItem
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<OrderItemDto>> OrderItem([FromRoute()] OrderItemIdDto idDto)
    {
        try
        {
            return await _service.OrderItem(idDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Get a Order record for OrderItem
    /// </summary>
    [HttpGet("{Id}/orders")]
    public async Task<ActionResult<List<OrderDto>>> GetOrder([FromRoute()] OrderItemIdDto idDto)
    {
        var order = await _service.GetOrder(idDto);
        return Ok(order);
    }

    /// <summary>
    /// Get a Product record for OrderItem
    /// </summary>
    [HttpGet("{Id}/products")]
    public async Task<ActionResult<List<ProductDto>>> GetProduct([FromRoute()] OrderItemIdDto idDto)
    {
        var product = await _service.GetProduct(idDto);
        return Ok(product);
    }

    /// <summary>
    /// Update one OrderItem
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateOrderItem(
        [FromRoute()] OrderItemIdDto idDto,
        [FromQuery()] OrderItemUpdateInput orderItemUpdateDto
    )
    {
        try
        {
            await _service.UpdateOrderItem(idDto, orderItemUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
