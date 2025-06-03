namespace DomAid.Entities.Extensions;

/// <summary>
/// Provides extension methods for setting common properties on entities derived from the <see cref="Entity"/> class.
/// </summary>
/// <remarks>
/// This class includes methods for setting the <c>Id</c>, <c>CreatedAt</c>, and <c>LastUpdate</c>
/// properties of an entity. These methods are designed to simplify the process of updating entity properties in a
/// fluent manner.
/// </remarks>
public static class EntityExtensions
{
    /// <summary>
    /// Sets the <see cref="Entity.Id"/> property of the specified entity to the given value.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity, which must inherit from <see cref="Entity"/>.</typeparam>
    /// <param name="entity">The entity whose <see cref="Entity.Id"/> property will be set. Cannot be <see langword="null"/>.</param>
    /// <param name="id">The value to assign to the <see cref="Entity.Id"/> property.</param>
    /// <returns>The updated entity with its <see cref="Entity.Id"/> property set to the specified value.</returns>
    public static TEntity SetId<TEntity>(this TEntity entity, long id) where TEntity : Entity
    {
        entity.Id = id;
        return entity;
    }

    /// <summary>
    /// Sets the <see cref="Entity.CreatedAt"/> property of the specified entity to the provided timestamp.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity, which must inherit from <see cref="Entity"/>.</typeparam>
    /// <param name="entity">The entity whose <see cref="Entity.CreatedAt"/> property is to be set. Cannot be <see langword="null"/>.</param>
    /// <param name="createdAt">The timestamp to assign to the <see cref="Entity.CreatedAt"/> property.</param>
    /// <returns>The updated entity with the <see cref="Entity.CreatedAt"/> property set to the specified timestamp.</returns>
    public static TEntity SetCreatedAt<TEntity>(this TEntity entity, DateTime createdAt) where TEntity : Entity
    {
        entity.CreatedAt = createdAt;
        return entity;
    }

    /// <summary>
    /// Sets the <see cref="Entity.LastUpdate"/> property of the specified entity to the provided date and time.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity, which must inherit from <see cref="Entity"/>.</typeparam>
    /// <param name="entity">The entity whose <see cref="Entity.LastUpdate"/> property will be updated. Cannot be <see langword="null"/>.</param>
    /// <param name="lastUpdate">The date and time to set as the last update for the entity.</param>
    /// <returns>The updated entity with its <see cref="Entity.LastUpdate"/> property set to the specified value.</returns>
    public static TEntity SetLastUpdate<TEntity>(this TEntity entity, DateTime lastUpdate) where TEntity : Entity
    {
        entity.LastUpdate = lastUpdate;
        return entity;
    }
}
