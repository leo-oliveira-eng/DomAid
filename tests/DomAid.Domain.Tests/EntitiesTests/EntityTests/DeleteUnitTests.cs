using DomAid.Domain.Tests.Shared;

namespace DomAid.Domain.Tests.EntitiesTests.EntityTests;

public class DeleteUnitTests
{
    [Fact]
    public void Delete_ShouldSetDeletedAtAndUpdateLastUpdate()
    {
        // Arrange
        var entity = new TestClass("Test", 123);

        // Act
        entity.Delete();

        // Assert
        entity.DeletedAt.ShouldNotBeNull();
        entity.Deleted.ShouldBeTrue();
        entity.LastUpdate.Date.ShouldBe(DateTime.UtcNow.Date);
    }
}
