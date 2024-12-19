using Ambev.DeveloperEvaluation.Application.Sale.CancelledSale;
using Ambev.DeveloperEvaluation.Application.Sale.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sale.GetAllSale;
using Ambev.DeveloperEvaluation.Application.Sale.GetSale;
using Ambev.DeveloperEvaluation.Application.Sale.UpdateSale;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelledSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetAllSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales;

[ApiController]
[Route("api/[controller]")]
public class SalesController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public SalesController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }


    [HttpPost]
    public async Task<IActionResult> CreateSale(CreateSaleRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var validator = new CreateSaleRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<CreateSaleCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            return Created(string.Empty, new ApiResponseWithData<CreateSaleResponse>
            {
                Success = true,
                Message = "Sale created successfully",
                Data = _mapper.Map<CreateSaleResponse>(response)
            });
        }
        catch (ValidationException ex)
        {
            return BadRequest(new ApiResponseWithData<CreateSaleResponse>
            {
                Success = false,
                Message = ex.Message,
                Data = null
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponseWithData<CreateSaleResponse>
            {
                Success = false,
                Message = ex.Message,
                Data = null
            });
        }
    }

    [HttpPatch("Cancel/{saleId}")]
    public async Task<IActionResult> CancelSale(Guid saleId, CancellationToken cancellationToken)
    {
        try
        {

            var command = new CancelledSaleCommand() { SaleId = saleId };
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(new ApiResponseWithData<CancelledSaleResponse>
            {
                Success = true,
                Message = "Sale Cancelleded successfully",
                Data = _mapper.Map<CancelledSaleResponse>(response)
            });
        }
        catch (ValidationException ex)
        {
            return BadRequest(new ApiResponseWithData<CancelledSaleResponse>
            {
                Success = false,
                Message = ex.Message,
                Data = null
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponseWithData<CancelledSaleResponse>
            {
                Success = false,
                Message = ex.Message,
                Data = null
            });
        }
    }

    [HttpPatch("Update")]
    public async Task<IActionResult> UpdateSale(UpdateSaleRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var validator = new UpdateSaleRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<UpdateSaleCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(new ApiResponseWithData<UpdateSaleResponse>
            {
                Success = true,
                Message = "Sale Updated successfully",
                Data = _mapper.Map<UpdateSaleResponse>(response)
            });
        }
        catch (ValidationException ex)
        {
            return BadRequest(new ApiResponseWithData<UpdateSaleResponse>
            {
                Success = false,
                Message = ex.Message,
                Data = null
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponseWithData<UpdateSaleResponse>
            {
                Success = false,
                Message = ex.Message,
                Data = null
            });
        }
    }

    [HttpGet("{saleId}")]
    public async Task<IActionResult> GetSale(Guid saleId, CancellationToken cancellationToken)
    {
        try
        {
            var command = new GetSaleCommand() { SaleId = saleId };
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(_mapper.Map<GetSaleResponse>(response));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponseWithData<GetSaleResponse>
            {
                Success = false,
                Message = ex.Message,
                Data = null
            });
        }
    }

    [HttpGet()]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        try
        {
            var command = new GetAllSaleCommand();
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(_mapper.Map<IList<GetAllSaleResponse>>(response));
        }
        catch (Exception ex)
        {
            return BadRequest(new ApiResponseWithData<GetAllSaleResponse>
            {
                Success = false,
                Message = ex.Message,
                Data = null
            });
        }
    }
}
