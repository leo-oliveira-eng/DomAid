using DomAid.Events;
using System.Diagnostics.CodeAnalysis;

namespace DomAid.Entities;

/// <summary>
/// Represents the base class for domain entities, providing common properties and methods  for managing entity state,
/// domain events, and lifecycle operations.
/// </summary>
/// <remarks>
/// This class is designed to be inherited by specific domain entity types. It includes  properties for
/// tracking entity metadata such as creation, update, and deletion timestamps,  as well as methods for managing domain
/// events and marking the entity as deleted.
/// </remarks>
public abstract class Entity
{
    #region Constants

    /// <summary>
    /// The message displayed when a constructor is marked as obsolete for use exclusively with Entity Framework.
    /// </summary>
    protected const string ConstructorObsoleteMessage = "Only for Entity Framework";

    #endregion

    #region Fields

    private readonly List<DomainEvent> _domainEvents = [];

    #endregion

    #region Properties

    /// <summary>
    /// Gets the unique identifier for the entity.
    /// </summary>
    public long Id { get; internal set; }

    /// <summary>
    /// Gets the unique identifier associated with this instance.
    /// </summary>
    public Guid Code { get; protected set; } = Guid.NewGuid();

    /// <summary>
    /// Gets the date and time when the entity was created, in Coordinated Universal Time (UTC).
    /// </summary>
    public DateTime CreatedAt { get; internal set; } = DateTime.UtcNow;

    /// <summary>
    /// Gets the timestamp of the most recent update to the object.
    /// </summary>
    public DateTime LastUpdate { get; internal set; } = DateTime.UtcNow;

    /// <summary>
    /// Gets the date and time when the entity was marked as deleted, or <see langword="null"/> if the entity has not been deleted.
    /// </summary>
    public DateTime? DeletedAt { get; private set; }

    /// <summary>
    /// Gets a value indicating whether the entity has been marked as deleted.
    /// </summary>
    public bool Deleted => DeletedAt.HasValue;

    /// <summary>
    /// Gets the collection of domain events associated with the current entity.
    /// </summary>
    /// <remarks>
    /// Domain events are typically used to signal changes or actions within the entity that may need
    /// to be handled by external systems. This property provides a snapshot of the events for processing or
    /// dispatching.
    /// </remarks>
    public IReadOnlyCollection<DomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="Entity"/> class.
    /// </summary>
    /// <remarks>
    /// This constructor is obsolete and should not be used. It is intended for internal use only.
    /// </remarks>
    [Obsolete(ConstructorObsoleteMessage, true), ExcludeFromCodeCoverage]
    protected Entity() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="Entity"/> class with the specified unique identifier.
    /// </summary>
    /// <remarks>
    /// The <paramref name="code"/> parameter is used to uniquely identify the entity instance.
    /// Ensure that the provided <see cref="Guid"/> is valid and unique within the context of your
    /// application.
    /// </remarks>
    /// <param name="code">The unique identifier for the entity. This value must not be <see langword="null"/>.</param>
    protected Entity(Guid code)
    {
        Code = code;
    }

    #endregion

    #region Methods

    /// <summary>
    /// Marks the entity as deleted by setting the deletion timestamp.
    /// </summary>
    /// <remarks>
    /// This method updates the <see cref="DeletedAt"/> property to the current UTC time, indicating
    /// when the entity was deleted. Additionally, it updates the <see cref="LastUpdate"/> property to reflect the time
    /// of the deletion.
    /// </remarks>
    public void Delete()
    {
        DeletedAt = DateTime.UtcNow;
        LastUpdate = DateTime.UtcNow;
    }

    /// <summary>
    /// Sets the <see cref="LastUpdate"/> property to the current date and time in UTC.
    /// </summary>
    /// <remarks>
    /// This method updates the <see cref="LastUpdate"/> property to reflect the current UTC
    /// timestamp. It is useful for tracking the last modification time of an object or entity.
    /// </remarks>
    public void SetLastUpdatedDateNow() => LastUpdate = DateTime.UtcNow;

    /// <summary>
    /// Adds a domain event to the collection of events associated with the current entity.
    /// </summary>
    /// <remarks>
    /// Domain events represent significant occurrences within the entity's lifecycle and are
    /// typically used to notify other parts of the system about changes or actions. Ensure that the provided  
    /// <paramref name="domainEvent"/> is properly initialized before adding it.
    /// </remarks>
    /// <param name="domainEvent">The domain event to add. Cannot be <see langword="null"/>.</param>
    public void AddDomainEvent(DomainEvent domainEvent) => _domainEvents.Add(domainEvent);

    /// <summary>
    /// Removes a specified domain event from the collection of domain events.
    /// </summary>
    /// <remarks>If the specified domain event is not found in the collection, no action is taken.</remarks>
    /// <param name="domainEvent">The domain event to remove. Cannot be <see langword="null"/>.</param>
    public void RemoveDomainEvent(DomainEvent domainEvent) => _domainEvents.Remove(domainEvent);

    /// <summary>
    /// Clears all domain events associated with the current entity.
    /// </summary>
    /// <remarks>
    /// This method removes all domain events from the internal collection, ensuring that no events 
    /// are retained. Use this method when you need to reset the state of domain events, typically  after they have been
    /// processed or dispatched.
    /// </remarks>
    public void ClearDomainEvents() => _domainEvents.Clear();

    #endregion
}
