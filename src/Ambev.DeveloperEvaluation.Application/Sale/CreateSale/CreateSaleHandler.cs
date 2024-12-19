using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sale.CreateSale;

public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
{

    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;

    public CreateSaleHandler(ISaleRepository saleRepository, IMapper mapper)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
    }

    public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var validator = new CreateSaleValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var sale = _mapper.Map<Domain.Entities.Sale>(command);

            sale.CalculateDiscountAndTotalAmountItems();
            sale.CalculateTotalAmuntSale();

            var createdSale = await _saleRepository.CreateAsync(sale, cancellationToken);
            Console.WriteLine($"SaleCreated: Sale ID {sale.Id}");

            var result = _mapper.Map<CreateSaleResult>(createdSale);
            return result;
        }
        catch (ValidationException ex)
        {
            throw new ValidationException(ex.Errors);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
