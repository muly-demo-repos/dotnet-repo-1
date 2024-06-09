using DotnetOrderService.APIs.Dtos;
using DotnetOrderService.Infrastructure.Models;

namespace DotnetOrderService.APIs.Extensions;

public static class PaymentsExtensions
{
    public static PaymentDto ToDto(this Payment model)
    {
        return new PaymentDto
        {
            Amount = model.Amount,
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            Method = model.Method,
            Order = new OrderIdDto { Id = model.OrderId },
            PaymentDate = model.PaymentDate,
            Status = model.Status,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static Payment ToModel(this PaymentUpdateInput updateDto, PaymentIdDto idDto)
    {
        var payment = new Payment
        {
            Id = idDto.Id,
            Amount = updateDto.Amount,
            Method = updateDto.Method,
            PaymentDate = updateDto.PaymentDate,
            Status = updateDto.Status
        };

        // map required fields
        if (updateDto.CreatedAt != null)
        {
            payment.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            payment.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return payment;
    }
}
