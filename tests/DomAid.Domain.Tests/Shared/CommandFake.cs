using DomAid.Messaging;
using Funcfy.Monads;

namespace DomAid.Domain.Tests.Shared;
internal class CommandFake : Command
{
    public override Result Validate()
        => Result.Success();
}
