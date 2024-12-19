using Ambev.DeveloperEvaluation.Application.Sale.UpdateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using Moq;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application;

public class UpdateSaleHandlerTests
{
    private readonly Mock<ISaleRepository> _saleRepositoryMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly UpdateSaleHandler _handler;

    public UpdateSaleHandlerTests()
    {
        _saleRepositoryMock = new Mock<ISaleRepository>();
        _mapperMock = new Mock<IMapper>();
        _handler = new UpdateSaleHandler(_saleRepositoryMock.Object, _mapperMock.Object);
    }

    [Fact]
    public async Task Handle_ValidCommand_UpdatesSaleSuccessfully()
    {
        // Arrange
        var command = new UpdateSaleCommand
        {
            Id = Guid.NewGuid(),
            Customer = "John Doe",
            Date = DateTime.UtcNow,
            Branch = "Main Branch",
            TotalAmount = 100.00m,
            IsCancelled = false,
            Items = new List<UpdateSaleItemCommand>
        {
            new UpdateSaleItemCommand
            {
                Id = Guid.NewGuid(),
                SaleId = Guid.NewGuid(),
                Product = "Product A",
                Quantity = 1,
                UnitPrice = 100.00m,
                Discount = 0,
                IsCancelled = false,
                TotalAmount = 100.00m
            }
        }
        };

        var saleEntity = new Sale(); // Simulação da entidade mapeada
        var updatedSaleEntity = new Sale { Id = command.Id.Value }; // Simulação do retorno do repositório
        var resultDto = new UpdateSaleResult { Id = command.Id }; // Simulação do mapeamento para o DTO de resultado

        _mapperMock.Setup(m => m.Map<DeveloperEvaluation.Domain.Entities.Sale>(command)).Returns(saleEntity);
        _saleRepositoryMock.Setup(repo => repo.UpdateAsync(saleEntity, It.IsAny<CancellationToken>())).ReturnsAsync(updatedSaleEntity);
        _mapperMock.Setup(m => m.Map<UpdateSaleResult>(updatedSaleEntity)).Returns(resultDto);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        _mapperMock.Verify(m => m.Map<DeveloperEvaluation.Domain.Entities.Sale>(command), Times.Once);
        _saleRepositoryMock.Verify(repo => repo.UpdateAsync(saleEntity, It.IsAny<CancellationToken>()), Times.Once);
        _mapperMock.Verify(m => m.Map<UpdateSaleResult>(updatedSaleEntity), Times.Once);
        Assert.NotNull(result);
        Assert.Equal(command.Id, result.Id);
    }

    [Fact]
    public async Task Handle_InvalidCommand_ThrowsValidationException()
    {
        // Arrange
        var command = new UpdateSaleCommand
        {
            Id = Guid.NewGuid(),
            Customer = "", // Inválido
            Branch = ""    // Inválido
        };

        // Act & Assert
        var exception = await Assert.ThrowsAsync<ValidationException>(() => _handler.Handle(command, CancellationToken.None));

        Assert.NotNull(exception);
        Assert.Contains("Customer", exception.Errors.Select(e => e.PropertyName));
        Assert.Contains("Branch", exception.Errors.Select(e => e.PropertyName));
    }
}
