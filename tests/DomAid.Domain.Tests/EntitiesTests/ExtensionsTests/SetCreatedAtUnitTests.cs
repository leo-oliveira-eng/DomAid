using DomAid.Domain.Tests.Shared;
using DomAid.Entities.Extensions;

namespace DomAid.Domain.Tests.EntitiesTests.ExtensionsTests;

public class SetCreatedAtUnitTests
{
    [Fact]
    public void SetCreatedAt_ShouldUpdateCreatedAtToSpecifiedDateTime()
    {
        // Arrange
        var entity = new TestClass("Test", 123);
        var specifiedDateTime = new DateTime(2023, 10, 1, 12, 0, 0);
        var initialCreatedAt = entity.CreatedAt;

        // Act
        entity.SetCreatedAt(specifiedDateTime);

        // Assert
        entity.CreatedAt.ShouldNotBe(initialCreatedAt);
        entity.CreatedAt.ShouldBe(specifiedDateTime);
    }
}
