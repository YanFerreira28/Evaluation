

using Ambev.DeveloperEvaluation.Application.Sale.CreateSale;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sale.UpdateSale;

internal class UpdateSaleValidator : AbstractValidator<UpdateSaleCommand>
{
    public UpdateSaleValidator()
    {
        RuleFor(sale => sale.Customer).NotEmpty().Length(3, 150);
        RuleFor(sale => sale.Branch).NotEmpty().Length(3, 150);
    }
}