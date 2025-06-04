using DomAid.Infrastructure;
using DomAid.Messaging;
using Funcfy.Monads;

namespace DomAid.Domain.Tests.Shared;

internal class FakeHandler(IUnitOfWork unitOfWork) : CommandHandler(unitOfWork)
{
    public async Task<Result> HandleAsync(CommandFake command)
    {
        command.Validate();
        return await CommitAsync();
    }
}
