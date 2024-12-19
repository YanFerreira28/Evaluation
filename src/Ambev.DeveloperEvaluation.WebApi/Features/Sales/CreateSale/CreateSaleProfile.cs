﻿using Ambev.DeveloperEvaluation.Application.Sale.CreateSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

public class CreateSaleProfile : Profile
{
    public CreateSaleProfile()
    {

        CreateMap<CreateSaleRequest, CreateSaleCommand>();
        CreateMap<CreateSaleResult, CreateSaleResponse>();
        CreateMap<SaleItemRequest, CreateSaleItemCommand>();
        CreateMap<SaleItemResult, SaleItemResponse>();
    }
}