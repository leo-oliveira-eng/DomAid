using DomAid.Domain.Tests.Shared;
using DomAid.Entities.Extensions;

namespace DomAid.Domain.Tests.EntitiesTests.ExtensionsTests;

public class SetLastUpdateUnitTests
{
    [Fact]
    public void SetLastUpdate_ShouldUpdateLastUpdateToSpecifiedDateTime()
    {
        // Arrange
        var entity = new TestClass("Test", 123);
        var specifiedDateTime = new DateTime(2023, 10, 1, 12, 0, 0);
        var initialLastUpdate = entity.LastUpdate;

        // Act
        entity.SetLastUpdate(specifiedDateTime);

        // Assert
        entity.LastUpdate.ShouldNotBe(initialLastUpdate);
        entity.LastUpdate.ShouldBe(specifiedDateTime);
    }
}
