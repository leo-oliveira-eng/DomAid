using DomAid.Domain.Tests.Shared;

namespace DomAid.Domain.Tests.EntitiesTests.EntityTests;

public class SetLastUpdateUnitTests
{
    [Fact]
    public void SetLastUpdate_ShouldUpdateLastUpdateToCurrentDateTime()
    {
        // Arrange
        var entity = new TestClass("Test", 123);
        var initialLastUpdate = entity.LastUpdate;

        // Act
        entity.SetLastUpdatedDateNow();

        // Assert
        entity.LastUpdate.ShouldNotBe(initialLastUpdate);
        entity.LastUpdate.Date.ShouldBe(DateTime.UtcNow.Date);
    }
}
