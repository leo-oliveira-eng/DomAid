using DomAid.Domain.Tests.Shared;
using DomAid.Infrastructure;
using Funcfy.Monads;
using Funcfy.Monads.Extensions;
using Moq;

namespace DomAid.Domain.Tests.MessagingTests.CommandHandlerTests;

public class CommitAsyncUnitTests
{
    [Fact]
    public async Task CommitAsync_ShouldReturnSuccess_WhenCommitIsSuccessful()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock.Setup(uow => uow.CommitAsync()).ReturnsAsync(true).Verifiable();
        
        var commandHandler = new FakeHandler(unitOfWorkMock.Object);

        // Act
        var result = await commandHandler.HandleAsync(new CommandFake());

        // Assert
        result.ShouldBeEquivalentTo(Result.Success());
        unitOfWorkMock.Verify();
    }

    [Fact]
    public async Task CommitAsync_ShouldReturnError_WhenCommitFails()
    {
        // Arrange
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock.Setup(uow => uow.CommitAsync()).ReturnsAsync(false).Verifiable();
                
        var commandHandler = new FakeHandler(unitOfWorkMock.Object);

        // Act
        var result = await commandHandler.HandleAsync(new CommandFake());

        // Assert
        result.ShouldBeEquivalentTo(Result.Create().WithServerError("Failed to commit data"));
        unitOfWorkMock.Verify();
    }
}
