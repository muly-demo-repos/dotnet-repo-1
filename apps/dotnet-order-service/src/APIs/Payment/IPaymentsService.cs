using DotnetOrderService.APIs.Dtos;

namespace DotnetOrderService.APIs;

public interface IPaymentsService
{
    /// <summary>
    /// Create one Payment
    /// </summary>
    public Task<PaymentDto> CreatePayment(PaymentCreateInput paymentDto);

    /// <summary>
    /// Delete one Payment
    /// </summary>
    public Task DeletePayment(PaymentIdDto idDto);

    /// <summary>
    /// Find many Payments
    /// </summary>
    public Task<List<PaymentDto>> Payments(PaymentFindMany findManyArgs);

    /// <summary>
    /// Get one Payment
    /// </summary>
    public Task<PaymentDto> Payment(PaymentIdDto idDto);

    /// <summary>
    /// Get a Order record for Payment
    /// </summary>
    public Task<OrderDto> GetOrder(PaymentIdDto idDto);

    /// <summary>
    /// Update one Payment
    /// </summary>
    public Task UpdatePayment(PaymentIdDto idDto, PaymentUpdateInput updateDto);
}
