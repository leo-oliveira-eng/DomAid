namespace DomAid.Events.Contracts;

/// <summary>
/// Represents a domain event that signifies an occurrence within the domain.
/// </summary>
/// <remarks>
/// Domain events are used to capture and communicate significant changes or actions within the domain.
/// Implementations of this interface typically include additional details specific to the event.
/// </remarks>
public interface IDomainEvent
{
    /// <summary>
    /// Gets the date and time when the event occurred.
    /// </summary>
    DateTimeOffset DateOccurred { get; }
}
