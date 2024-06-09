using DotnetOrderService.APIs;
using DotnetOrderService.APIs.Dtos;
using DotnetOrderService.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace DotnetOrderService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class OrdersControllerBase : ControllerBase
{
    protected readonly IOrdersService _service;

    public OrdersControllerBase(IOrdersService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Order
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<OrderDto>> CreateOrder(OrderCreateInput input)
    {
        var order = await _service.CreateOrder(input);

        return CreatedAtAction(nameof(Order), new { id = order.Id }, order);
    }

    /// <summary>
    /// Delete one Order
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteOrder([FromRoute()] OrderIdDto idDto)
    {
        try
        {
            await _service.DeleteOrder(idDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Orders
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<OrderDto>>> Orders([FromQuery()] OrderFindMany filter)
    {
        return Ok(await _service.Orders(filter));
    }

    /// <summary>
    /// Get one Order
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<OrderDto>> Order([FromRoute()] OrderIdDto idDto)
    {
        try
        {
            return await _service.Order(idDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Connect multiple OrderItems records to Order
    /// </summary>
    [HttpPost("{Id}/orderItems")]
    public async Task<ActionResult> ConnectOrderItems(
        [FromRoute()] OrderIdDto idDto,
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
    /// Connect multiple Payments records to Order
    /// </summary>
    [HttpPost("{Id}/payments")]
    public async Task<ActionResult> ConnectPayments(
        [FromRoute()] OrderIdDto idDto,
        [FromQuery()] PaymentIdDto[] paymentsId
    )
    {
        try
        {
            await _service.ConnectPayments(idDto, paymentsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple OrderItems records from Order
    /// </summary>
    [HttpDelete("{Id}/orderItems")]
    public async Task<ActionResult> DisconnectOrderItems(
        [FromRoute()] OrderIdDto idDto,
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
    /// Disconnect multiple Payments records from Order
    /// </summary>
    [HttpDelete("{Id}/payments")]
    public async Task<ActionResult> DisconnectPayments(
        [FromRoute()] OrderIdDto idDto,
        [FromBody()] PaymentIdDto[] paymentsId
    )
    {
        try
        {
            await _service.DisconnectPayments(idDto, paymentsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple OrderItems records for Order
    /// </summary>
    [HttpGet("{Id}/orderItems")]
    public async Task<ActionResult<List<OrderItemDto>>> FindOrderItems(
        [FromRoute()] OrderIdDto idDto,
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
    /// Find multiple Payments records for Order
    /// </summary>
    [HttpGet("{Id}/payments")]
    public async Task<ActionResult<List<PaymentDto>>> FindPayments(
        [FromRoute()] OrderIdDto idDto,
        [FromQuery()] PaymentFindMany filter
    )
    {
        try
        {
            return Ok(await _service.FindPayments(idDto, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Get a Customer record for Order
    /// </summary>
    [HttpGet("{Id}/customers")]
    public async Task<ActionResult<List<CustomerDto>>> GetCustomer([FromRoute()] OrderIdDto idDto)
    {
        var customer = await _service.GetCustomer(idDto);
        return Ok(customer);
    }

    /// <summary>
    /// Update multiple OrderItems records for Order
    /// </summary>
    [HttpPatch("{Id}/orderItems")]
    public async Task<ActionResult> UpdateOrderItems(
        [FromRoute()] OrderIdDto idDto,
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
    /// Update multiple Payments records for Order
    /// </summary>
    [HttpPatch("{Id}/payments")]
    public async Task<ActionResult> UpdatePayments(
        [FromRoute()] OrderIdDto idDto,
        [FromBody()] PaymentIdDto[] paymentsId
    )
    {
        try
        {
            await _service.UpdatePayments(idDto, paymentsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Update one Order
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateOrder(
        [FromRoute()] OrderIdDto idDto,
        [FromQuery()] OrderUpdateInput orderUpdateDto
    )
    {
        try
        {
            await _service.UpdateOrder(idDto, orderUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
