using FluentValidation;


namespace Ambev.DeveloperEvaluation.Application.Sale.CreateSale;
    public class CreateSaleValidator : AbstractValidator<CreateSaleCommand>
    {
        public CreateSaleValidator()
        {
            RuleFor(sale => sale.Customer).NotEmpty().Length(3, 150);
            RuleFor(sale => sale.Branch).NotEmpty().Length(3, 150);
        }
    }
