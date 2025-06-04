using DomAid.Entities;
using Funcfy.Monads;

namespace DomAid.Infrastructure;

/// <summary>
/// Defines a read-only repository for accessing entities of type <typeparamref name="TEntity"/>.
/// </summary>
/// <remarks>
/// This interface provides methods for retrieving entities from a data source, including fetching all
/// entities or finding specific entities by their unique identifiers.
/// </remarks>
/// <typeparam name="TEntity">The type of entity managed by the repository. Must inherit from <see cref="Entity"/>.</typeparam>
public interface IReadRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    /// <summary>
    /// Asynchronously retrieves all entities of type <typeparamref name="TEntity"/> from the data source.
    /// </summary>
    /// <remarks>
    /// This method is typically used to retrieve all records of a specific entity type from a
    /// repository or database. Ensure that the data source contains entities of the specified type before calling this
    /// method.
    /// </remarks>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains a list of all entities of type
    /// <typeparamref name="TEntity"/>. If no entities are found, the returned list will be empty.
    /// </returns>
    Task<List<TEntity>> GetAllAsync();

    /// <summary>
    /// Gets an entity by its unique identifier asynchronously.
    /// </summary>
    /// <param name="code">The unique identifier of the entity to retrieve.</param>
    /// <returns>
    /// A <see cref="Maybe{TEntity}"/> that contains the entity if found, or an empty"/>
    /// </returns>
    Task<Maybe<TEntity>> FindAsync(Guid code);

    /// <summary>
    /// Retrieves a list of entities that match the specified unique identifiers.
    /// </summary>
    /// <remarks>
    /// This method performs an asynchronous operation to retrieve entities based on their unique
    /// identifiers. Ensure that the provided identifiers correspond to existing entities in the data source.
    /// </remarks>
    /// <param name="codes">A list of unique identifiers (<see cref="Guid"/>) used to locate the entities. Cannot be null or empty.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of entities of type
    /// <typeparamref name="TEntity"/> that match the provided identifiers. If no matches are found, the list will be
    /// empty.</returns>
    Task<List<TEntity>> FindAsync(List<Guid> codes);
}
