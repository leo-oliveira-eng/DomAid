using DomAid.Domain.Tests.Shared;

namespace DomAid.Domain.Tests.EntitiesTests.EntityTests;

public class ClearDomainEventsUnitTests
{
    [Fact]
    public void ClearDomainEvents_ShouldEmptyDomainEventsList()
    {
        // Arrange
        var entity = new TestClass("Test", 123);
        var domainEvent1 = new FakeDomainEvent(Guid.NewGuid());
        var domainEvent2 = new FakeDomainEvent(Guid.NewGuid());
        
        entity.AddDomainEvent(domainEvent1);
        entity.AddDomainEvent(domainEvent2);
        // Act
        entity.ClearDomainEvents();
        // Assert
        entity.DomainEvents.ShouldBeEmpty();
    }
}
