using FurnitureStoreService.APIs.Common;
using FurnitureStoreService.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureStoreService.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class SupplierFindMany : FindManyInput<Supplier, SupplierWhereInput> { }