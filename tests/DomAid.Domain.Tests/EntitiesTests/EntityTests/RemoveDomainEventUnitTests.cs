using DomAid.Domain.Tests.Shared;

namespace DomAid.Domain.Tests.EntitiesTests.EntityTests;

public class RemoveDomainEventUnitTests
{
    [Fact]
    public void RemoveDomainEvent_ShouldRemoveEventFromDomainEventsList()
    {
        // Arrange
        var entity = new TestClass("Test", 123);
        var domainEvent = new FakeDomainEvent(Guid.NewGuid());
        entity.AddDomainEvent(domainEvent);

        // Act
        entity.RemoveDomainEvent(domainEvent);

        // Assert
        entity.DomainEvents.ShouldNotContain(domainEvent);
    }
}
