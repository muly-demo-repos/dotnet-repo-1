using DotnetOrderService.APIs;
using DotnetOrderService.APIs.Common;
using DotnetOrderService.APIs.Dtos;
using DotnetOrderService.APIs.Errors;
using DotnetOrderService.APIs.Extensions;
using DotnetOrderService.Infrastructure;
using DotnetOrderService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetOrderService.APIs;

public abstract class PaymentsServiceBase : IPaymentsService
{
    protected readonly DotnetOrderServiceDbContext _context;

    public PaymentsServiceBase(DotnetOrderServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Payment
    /// </summary>
    public async Task<PaymentDto> CreatePayment(PaymentCreateInput createDto)
    {
        var payment = new Payment
        {
            Amount = createDto.Amount,
            CreatedAt = createDto.CreatedAt,
            Method = createDto.Method,
            PaymentDate = createDto.PaymentDate,
            Status = createDto.Status,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            payment.Id = createDto.Id;
        }
        if (createDto.Order != null)
        {
            payment.Order = await _context
                .Orders.Where(order => createDto.Order.Id == order.Id)
                .FirstOrDefaultAsync();
        }

        _context.Payments.Add(payment);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<Payment>(payment.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Payment
    /// </summary>
    public async Task DeletePayment(PaymentIdDto idDto)
    {
        var payment = await _context.Payments.FindAsync(idDto.Id);
        if (payment == null)
        {
            throw new NotFoundException();
        }

        _context.Payments.Remove(payment);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Payments
    /// </summary>
    public async Task<List<PaymentDto>> Payments(PaymentFindMany findManyArgs)
    {
        var payments = await _context
            .Payments.Include(x => x.Order)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return payments.ConvertAll(payment => payment.ToDto());
    }

    /// <summary>
    /// Get one Payment
    /// </summary>
    public async Task<PaymentDto> Payment(PaymentIdDto idDto)
    {
        var payments = await this.Payments(
            new PaymentFindMany { Where = new PaymentWhereInput { Id = idDto.Id } }
        );
        var payment = payments.FirstOrDefault();
        if (payment == null)
        {
            throw new NotFoundException();
        }

        return payment;
    }

    /// <summary>
    /// Get a Order record for Payment
    /// </summary>
    public async Task<OrderDto> GetOrder(PaymentIdDto idDto)
    {
        var payment = await _context
            .Payments.Where(payment => payment.Id == idDto.Id)
            .Include(payment => payment.Order)
            .FirstOrDefaultAsync();
        if (payment == null)
        {
            throw new NotFoundException();
        }
        return payment.Order.ToDto();
    }

    /// <summary>
    /// Update one Payment
    /// </summary>
    public async Task UpdatePayment(PaymentIdDto idDto, PaymentUpdateInput updateDto)
    {
        var payment = updateDto.ToModel(idDto);

        _context.Entry(payment).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Payments.Any(e => e.Id == payment.Id))
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
