using DomAid.Infrastructure;
using Funcfy.Monads;
using Funcfy.Monads.Extensions;

namespace DomAid.Messaging;

/// <summary>
/// Provides a base class for handling commands that require interaction with a unit of work.
/// </summary>
/// <remarks>
/// This abstract class is designed to facilitate the implementation of command handlers that rely on a
/// unit of work for managing transactional operations. It provides a protected method, <see cref="CommitAsync"/>, to
/// commit changes asynchronously and handle the result of the operation. Derived classes should use the provided <see
/// cref="IUnitOfWork"/> instance to perform transactional operations.
/// </remarks>
/// <param name="unitOfWork">
/// Interface for the unit of work that manages database transactions. 
/// this parameter is required to ensure that the command handler can commit changes to the database.
/// </param>
public abstract class CommandHandler(IUnitOfWork unitOfWork)
{
    IUnitOfWork UnitOfWork { get; } = unitOfWork;

    /// <summary>
    /// Commits the current unit of work asynchronously and returns the result of the operation.
    /// </summary>
    /// <remarks>
    /// This method attempts to persist changes made within the current unit of work. If the commit operation fails, 
    /// an error result is returned. Ensure that the unit of work is properly configured before calling this method.
    /// </remarks>
    /// <returns>
    /// A <see cref="Result"/> indicating the outcome of the commit operation. Returns a success result if the commit is
    /// successful; otherwise, returns a result with a server error.
    /// </returns>
    protected async Task<Result> CommitAsync()
    {
        if (!await UnitOfWork.CommitAsync())
            return Result.Create().WithServerError("Failed to commit data");

        return Result.Success();
    }
}
