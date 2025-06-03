using DomAid.Domain.Tests.Shared;

namespace DomAid.Domain.Tests.EntitiesTests.EntityTests;

public class AddDomainEventUnitTests
{
    [Fact]
    public void AddDomainEvent_ShouldAddEventToDomainEventsList()
    {
        // Arrange
        var entity = new TestClass("Test", 123);
        var domainEvent = new FakeDomainEvent(Guid.NewGuid());

        // Act
        entity.AddDomainEvent(domainEvent);

        // Assert
        entity.DomainEvents.ShouldContain(domainEvent);
    }
}
