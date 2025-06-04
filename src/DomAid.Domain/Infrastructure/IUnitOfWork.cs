namespace DomAid.Infrastructure;

/// <summary>
/// Represents a unit of work that encapsulates a set of operations to be committed as a single transaction.
/// </summary>
/// <remarks>
/// The <see cref="IUnitOfWork"/> interface is typically used to coordinate changes across multiple
/// repositories or data sources, ensuring that all changes are committed together or rolled back in case of
/// failure.
/// </remarks>
public interface IUnitOfWork
{
    /// <summary>
    /// Asynchronously commits the changes made in the unit of work to the underlying data store.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result is a boolean indicating whether the commit was successful.
    /// </returns>
    Task<bool> CommitAsync();
}
