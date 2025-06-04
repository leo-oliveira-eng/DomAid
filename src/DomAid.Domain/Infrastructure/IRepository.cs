using DomAid.Entities;

namespace DomAid.Infrastructure;

/// <summary>
/// Defines a generic repository for managing entities of type <typeparamref name="TEntity"/>.
/// </summary>
/// <remarks>
/// This interface provides a contract for implementing data access operations for entities.
/// Implementations of this interface are expected to handle the persistence and retrieval of <typeparamref
/// name="TEntity"/> objects, typically from a database or other storage mechanism.
/// </remarks>
/// <typeparam name="TEntity">The type of entity managed by the repository. Must inherit from <see cref="Entity"/>.</typeparam>
public interface IRepository<TEntity> where TEntity : Entity { }
