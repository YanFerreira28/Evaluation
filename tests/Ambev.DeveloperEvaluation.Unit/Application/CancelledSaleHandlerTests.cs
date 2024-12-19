using Ambev.DeveloperEvaluation.Application.Sale.CancelledSale;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using Moq;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application
{
    public class CancelledSaleHandlerTests
    {
        private readonly Mock<ISaleRepository> _saleRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly CancelledSaleHandler _handler;

        public CancelledSaleHandlerTests()
        {
            _saleRepositoryMock = new Mock<ISaleRepository>();
            _mapperMock = new Mock<IMapper>();
            _handler = new CancelledSaleHandler(_saleRepositoryMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task Handle_ValidCommand_CancelsSaleSuccessfully()
        {
            var command = new CancelledSaleCommand
            {
                SaleId = Guid.NewGuid()
            };

            _saleRepositoryMock
                .Setup(repo => repo.CancelSaleAsync(command.SaleId, It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            var result = await _handler.Handle(command, CancellationToken.None);

            _saleRepositoryMock.Verify(repo => repo.CancelSaleAsync(command.SaleId, It.IsAny<CancellationToken>()), Times.Once);
            Assert.NotNull(result);
            Assert.Equal(command.SaleId, result.SaleId);
        }

        [Fact]
        public async Task Handle_InvalidCommand_ThrowsValidationException()
        {
            var command = new CancelledSaleCommand
            {
                SaleId = Guid.Empty 
            };

            var exception = await Assert.ThrowsAsync<ValidationException>(() => _handler.Handle(command, CancellationToken.None));

            Assert.NotNull(exception);
            Assert.Contains("SaleId", exception.Errors.Select(e => e.PropertyName));
        }
    }
}
