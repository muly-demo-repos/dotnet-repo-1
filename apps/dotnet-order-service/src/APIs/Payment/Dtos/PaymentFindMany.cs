using DotnetOrderService.APIs.Common;
using DotnetOrderService.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotnetOrderService.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class PaymentFindMany : FindManyInput<Payment, PaymentWhereInput> { }
