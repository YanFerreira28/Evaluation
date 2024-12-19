using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sale.UpdateSale;

public class UpdateSaleHandler : IRequestHandler<UpdateSaleCommand, UpdateSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;

    public UpdateSaleHandler(ISaleRepository saleRepository, IMapper mapper)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
    }

    public async Task<UpdateSaleResult> Handle(UpdateSaleCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var validator = new UpdateSaleValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var sale = _mapper.Map<Domain.Entities.Sale>(command);

            var createdSale = await _saleRepository.UpdateAsync(sale, cancellationToken);
            Console.WriteLine($"SaleCreated: Sale ID {sale.Id}");

            var result = _mapper.Map<UpdateSaleResult>(createdSale);
            return result;
        }
        catch(ValidationException e)
        {
            throw new ValidationException(e.Errors);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
