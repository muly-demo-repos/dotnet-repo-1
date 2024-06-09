using DotnetOrderService.APIs;
using DotnetOrderService.APIs.Dtos;
using DotnetOrderService.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace DotnetOrderService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class PaymentsControllerBase : ControllerBase
{
    protected readonly IPaymentsService _service;

    public PaymentsControllerBase(IPaymentsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Payment
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<PaymentDto>> CreatePayment(PaymentCreateInput input)
    {
        var payment = await _service.CreatePayment(input);

        return CreatedAtAction(nameof(Payment), new { id = payment.Id }, payment);
    }

    /// <summary>
    /// Delete one Payment
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeletePayment([FromRoute()] PaymentIdDto idDto)
    {
        try
        {
            await _service.DeletePayment(idDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Payments
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<PaymentDto>>> Payments([FromQuery()] PaymentFindMany filter)
    {
        return Ok(await _service.Payments(filter));
    }

    /// <summary>
    /// Get one Payment
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<PaymentDto>> Payment([FromRoute()] PaymentIdDto idDto)
    {
        try
        {
            return await _service.Payment(idDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Get a Order record for Payment
    /// </summary>
    [HttpGet("{Id}/orders")]
    public async Task<ActionResult<List<OrderDto>>> GetOrder([FromRoute()] PaymentIdDto idDto)
    {
        var order = await _service.GetOrder(idDto);
        return Ok(order);
    }

    /// <summary>
    /// Update one Payment
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdatePayment(
        [FromRoute()] PaymentIdDto idDto,
        [FromQuery()] PaymentUpdateInput paymentUpdateDto
    )
    {
        try
        {
            await _service.UpdatePayment(idDto, paymentUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
