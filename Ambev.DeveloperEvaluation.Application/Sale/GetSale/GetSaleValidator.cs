using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sale.GetSale;

internal class GetSaleValidator : AbstractValidator<GetSaleCommand>
{
    public GetSaleValidator()
    {
        RuleFor(sale => sale.SaleId).NotNull();
    }
}