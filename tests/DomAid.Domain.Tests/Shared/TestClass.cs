using DomAid.Entities;

namespace DomAid.Domain.Tests.Shared;

public class TestClass(string anyProperty, int anotherProperty) : Entity(Guid.NewGuid())
{
    public string AnyProperty { get; set; } = anyProperty;
    public int AnotherProperty { get; set; } = anotherProperty;
}
