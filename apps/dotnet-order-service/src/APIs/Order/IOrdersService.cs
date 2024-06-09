using DotnetOrderService.APIs.Dtos;

namespace DotnetOrderService.APIs;

public interface IOrdersService
{
    /// <summary>
    /// Create one Order
    /// </summary>
    public Task<OrderDto> CreateOrder(OrderCreateInput orderDto);

    /// <summary>
    /// Delete one Order
    /// </summary>
    public Task DeleteOrder(OrderIdDto idDto);

    /// <summary>
    /// Find many Orders
    /// </summary>
    public Task<List<OrderDto>> Orders(OrderFindMany findManyArgs);

    /// <summary>
    /// Get one Order
    /// </summary>
    public Task<OrderDto> Order(OrderIdDto idDto);

    /// <summary>
    /// Connect multiple OrderItems records to Order
    /// </summary>
    public Task ConnectOrderItems(OrderIdDto idDto, OrderItemIdDto[] orderItemsId);

    /// <summary>
    /// Connect multiple Payments records to Order
    /// </summary>
    public Task ConnectPayments(OrderIdDto idDto, PaymentIdDto[] paymentsId);

    /// <summary>
    /// Disconnect multiple OrderItems records from Order
    /// </summary>
    public Task DisconnectOrderItems(OrderIdDto idDto, OrderItemIdDto[] orderItemsId);

    /// <summary>
    /// Disconnect multiple Payments records from Order
    /// </summary>
    public Task DisconnectPayments(OrderIdDto idDto, PaymentIdDto[] paymentsId);

    /// <summary>
    /// Find multiple OrderItems records for Order
    /// </summary>
    public Task<List<OrderItemDto>> FindOrderItems(
        OrderIdDto idDto,
        OrderItemFindMany OrderItemFindMany
    );

    /// <summary>
    /// Find multiple Payments records for Order
    /// </summary>
    public Task<List<PaymentDto>> FindPayments(OrderIdDto idDto, PaymentFindMany PaymentFindMany);

    /// <summary>
    /// Get a Customer record for Order
    /// </summary>
    public Task<CustomerDto> GetCustomer(OrderIdDto idDto);

    /// <summary>
    /// Update multiple OrderItems records for Order
    /// </summary>
    public Task UpdateOrderItems(OrderIdDto idDto, OrderItemIdDto[] orderItemsId);

    /// <summary>
    /// Update multiple Payments records for Order
    /// </summary>
    public Task UpdatePayments(OrderIdDto idDto, PaymentIdDto[] paymentsId);

    /// <summary>
    /// Update one Order
    /// </summary>
    public Task UpdateOrder(OrderIdDto idDto, OrderUpdateInput updateDto);
}
