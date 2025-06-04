using DomAid.Entities;

namespace DomAid.Infrastructure;

/// <summary>
/// Defines a repository interface for performing write operations on entities of type <typeparamref name="TEntity"/>.
/// </summary>
/// <remarks>
/// This interface provides methods for adding, removing, and updating entities in bulk or individually.
/// It extends <see cref="IRepository{TEntity}"/>, which may include additional functionality for managing
/// entities.
/// </remarks>
/// <typeparam name="TEntity">The type of entity that the repository manages. Must inherit from <see cref="Entity"/>.</typeparam>
public interface IWriteRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    /// <summary>
    /// Asynchronously adds the specified entity to the data store.
    /// </summary>
    /// <param name="entity">The entity to add. Cannot be <see langword="null"/>.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task AddAsync(TEntity entity);

    /// <summary>
    /// Asynchronously adds a collection of entities to the data store.
    /// </summary>
    /// <param name="entities">The list of entities to add. Cannot be null or empty.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task AddAsync(List<TEntity> entities);

    /// <summary>
    /// Asynchronously removes the specified entity from the data source.
    /// </summary>
    /// <param name="entity">The entity to be removed. Cannot be <see langword="null"/>.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task RemoveAsync(TEntity entity);

    /// <summary>
    /// Removes the specified entities from the data store asynchronously.
    /// </summary>
    /// <remarks>If any of the entities do not exist in the data store, they will be ignored. This method does
    /// not throw an exception for non-existent entities.</remarks>
    /// <param name="entities">A list of entities to be removed. Cannot be null or empty.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task RemoveAsync(List<TEntity> entities);

    /// <summary>
    /// Asynchronously updates the specified entity in the data store.
    /// </summary>
    /// <param name="entity">The entity to update. Must not be <see langword="null"/>.</param>
    /// <returns>A task that represents the asynchronous update operation.</returns>
    Task UpdateAsync(TEntity entity);

    /// <summary>
    /// Updates the specified collection of entities in the data store asynchronously.
    /// </summary>
    /// <remarks>The method performs an update operation for each entity in the provided list.  Ensure that
    /// the entities have valid identifiers and meet any preconditions required by the data store.</remarks>
    /// <param name="entities">A list of entities to be updated. Each entity must already exist in the data store.</param>
    /// <returns>A task that represents the asynchronous update operation.</returns>
    Task UpdateAsync(List<TEntity> entities);
}
