using DomAid.Domain.Tests.Shared;
using DomAid.Entities.Extensions;

namespace DomAid.Domain.Tests.EntitiesTests.ExtensionsTests;

public class SetIdUnitTests
{
    [Fact]
    public void SetId_ShouldSetIdProperty()
    {
        // Arrange
        var entity = new TestClass("Test", 123);
        long newId = 456;

        // Act
        entity.SetId(newId);

        // Assert
        entity.Id.ShouldBe(newId);
    }
}
