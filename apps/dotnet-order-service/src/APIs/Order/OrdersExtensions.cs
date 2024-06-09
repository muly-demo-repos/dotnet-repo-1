using DotnetOrderService.APIs.Dtos;
using DotnetOrderService.Infrastructure.Models;

namespace DotnetOrderService.APIs.Extensions;

public static class OrdersExtensions
{
    public static OrderDto ToDto(this Order model)
    {
        return new OrderDto
        {
            CreatedAt = model.CreatedAt,
            Customer = new CustomerIdDto { Id = model.CustomerId },
            Id = model.Id,
            OrderDate = model.OrderDate,
            OrderItems = model.OrderItems?.Select(x => new OrderItemIdDto { Id = x.Id }).ToList(),
            Payments = model.Payments?.Select(x => new PaymentIdDto { Id = x.Id }).ToList(),
            Status = model.Status,
            TotalAmount = model.TotalAmount,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static Order ToModel(this OrderUpdateInput updateDto, OrderIdDto idDto)
    {
        var order = new Order
        {
            Id = idDto.Id,
            OrderDate = updateDto.OrderDate,
            Status = updateDto.Status,
            TotalAmount = updateDto.TotalAmount
        };

        // map required fields
        if (updateDto.CreatedAt != null)
        {
            order.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            order.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return order;
    }
}
