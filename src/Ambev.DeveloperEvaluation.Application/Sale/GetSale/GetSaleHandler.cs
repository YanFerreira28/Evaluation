using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sale.GetSale;

public class GetSaleHandler : IRequestHandler<GetSaleCommand, GetSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;

    public GetSaleHandler(ISaleRepository saleRepository, IMapper mapper)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
    }

    public async Task<GetSaleResult> Handle(GetSaleCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var validator = new GetSaleValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var response = await _saleRepository.GetByIdAsync(command.SaleId, cancellationToken);
            Console.WriteLine($"GetSale: Sale ID {command.SaleId}");

            if (response == null)
                throw new NullReferenceException("Sale not found");


            return _mapper.Map<GetSaleResult>(response);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
