using Ambev.DeveloperEvaluation.Application.Sale.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using Moq;
using FluentValidation;
using Xunit;
using Ambev.DeveloperEvaluation.ORM.Repositories;

namespace Ambev.DeveloperEvaluation.Unit.Application;

public class CreateSaleHandlerTests
{
    private readonly Mock<ISaleRepository> _saleRepositoryMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly CreateSaleHandler _handler;

    public CreateSaleHandlerTests()
    {
        _saleRepositoryMock = new Mock<ISaleRepository>();
        _mapperMock = new Mock<IMapper>();
        _handler = new CreateSaleHandler(_saleRepositoryMock.Object, _mapperMock.Object);
    }

    [Fact]
    public async Task Handle_ValidCommand_ReturnsCreateSaleResult()
    {
        var command = new CreateSaleCommand
        {
            Customer = "Test Customer",
            Branch = "Main Branch",
            Items = new List<CreateSaleItemCommand>
        {
            new CreateSaleItemCommand { Product = "Product A", Quantity = 2, UnitPrice = 50m },
            new CreateSaleItemCommand { Product = "Product B", Quantity = 1, UnitPrice = 100m }
        }
        };

        var saleEntity = new Sale
        {
            Id = Guid.NewGuid(),
            Customer = command.Customer,
            Branch = command.Branch,
            Items = command.Items.Select(i => new SaleItem
            {
                Product = i.Product,
                Quantity = i.Quantity,
                UnitPrice = i.UnitPrice
            }).ToList()
        };

        saleEntity.CalculateDiscountAndTotalAmountItems();
        saleEntity.CalculateTotalAmuntSale();

        var createdSaleEntity = new Sale
        {
            Id = saleEntity.Id,
            Customer = saleEntity.Customer,
            Branch = saleEntity.Branch,
            TotalAmount = saleEntity.TotalAmount,
            Items = saleEntity.Items
        };

        var saleResult = new CreateSaleResult
        {
            Id = createdSaleEntity.Id,
            Customer = createdSaleEntity.Customer,
            Date = createdSaleEntity.Date,
            Branch = createdSaleEntity.Branch,
            TotalAmount = createdSaleEntity.TotalAmount,
            Items = createdSaleEntity.Items.Select(i => new SaleItemResult
            {
                Product = i.Product,
                Quantity = i.Quantity,
                UnitPrice = i.UnitPrice,
                Discount = i.Discount,
                TotalAmount = i.TotalAmount
            }).ToList()
        };

        _mapperMock.Setup(m => m.Map<Sale>(command)).Returns(saleEntity);
        _saleRepositoryMock.Setup(repo => repo.CreateAsync(saleEntity, It.IsAny<CancellationToken>()))
            .ReturnsAsync(createdSaleEntity);
        _mapperMock.Setup(m => m.Map<CreateSaleResult>(createdSaleEntity)).Returns(saleResult);

        var result = await _handler.Handle(command, CancellationToken.None);

        Assert.NotNull(result);
        Assert.Equal(saleResult.Id, result.Id);
        Assert.Equal(saleResult.TotalAmount, result.TotalAmount);

        _mapperMock.Verify(m => m.Map<Sale>(command), Times.Once);
        _saleRepositoryMock.Verify(repo => repo.CreateAsync(saleEntity, It.IsAny<CancellationToken>()), Times.Once);
        _mapperMock.Verify(m => m.Map<CreateSaleResult>(createdSaleEntity), Times.Once);
    }

    [Fact]
    public async Task Handle_InvalidCommand_ThrowsValidationException()
    {
        // Arrange
        var command = new CreateSaleCommand
        {
            Customer = "",
            Branch = "",  
            Items = new List<CreateSaleItemCommand>()
        };

        var handler = new CreateSaleHandler(_saleRepositoryMock.Object, _mapperMock.Object);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<ValidationException>(() => handler.Handle(command, CancellationToken.None));

        Assert.NotNull(exception);
        Assert.Contains("Customer", exception.Errors.Select(e => e.PropertyName));
        Assert.Contains("Branch", exception.Errors.Select(e => e.PropertyName));
    }

    [Fact]
    public async Task Handle_RepositoryThrowsException_RethrowsException()
    {
        var command = new CreateSaleCommand
        {
            Customer = "Test Customer",
            Branch = "Main Branch",
            Items = new List<CreateSaleItemCommand>
        {
            new CreateSaleItemCommand { Product = "Product A", Quantity = 2, UnitPrice = 50m }
        }
        };

        var saleEntity = new Sale
        {
            Id = Guid.NewGuid(),
            Customer = command.Customer,
            Branch = command.Branch,
            Items = command.Items.Select(i => new SaleItem
            {
                Product = i.Product,
                Quantity = i.Quantity,
                UnitPrice = i.UnitPrice
            }).ToList()
        };

        _mapperMock.Setup(m => m.Map<Sale>(command)).Returns(saleEntity);
        _saleRepositoryMock.Setup(repo => repo.CreateAsync(saleEntity, It.IsAny<CancellationToken>()))
            .ThrowsAsync(new Exception("Repository error"));

        var exception = await Assert.ThrowsAsync<Exception>(() => _handler.Handle(command, CancellationToken.None));
        Assert.Equal("Repository error", exception.Message);
    }
}
