using DomAid.Events.Contracts;

namespace DomAid.Events;

/// <summary>
/// Represents a base class for domain events associated with a specific aggregate. Domain events capture changes within
/// the domain that are relevant to other parts of the system.
/// </summary>
/// <remarks>
/// A domain event is typically used in event-driven architectures to signal state changes in an
/// aggregate. This class provides common properties for domain events, such as the aggregate identifier and a flag
/// indicating whether the event has been published.
/// </remarks>
/// <param name="aggregateId">The unique identifier for the aggregate associated with this event. This identifier is used to correlate the event</param>
public abstract class DomainEvent(Guid aggregateId) : Event, IDomainEvent
{
    /// <summary>
    /// Gets or sets a value indicating whether the item is published.
    /// </summary>
    public bool IsPublished { get; set; } = false;

    /// <summary>
    /// Gets or sets the unique identifier for the aggregate.
    /// </summary>
    public Guid AggregateId { get; set; } = aggregateId;
}
