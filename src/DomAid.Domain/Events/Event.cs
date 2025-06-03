using MediatR;

namespace DomAid.Events;

/// <summary>
/// Represents an abstract base class for events that can be used in a notification system.
/// </summary>
/// <remarks>
/// This class provides a common structure for events, including a timestamp indicating when the event
/// occurred. Derived classes should define specific event details.
/// </remarks>
public abstract class Event : INotification
{
    /// <summary>
    /// Gets the date and time when the event occurred, expressed as a UTC offset.
    /// </summary>
    public DateTimeOffset DateOccurred { get; protected set; } = DateTime.UtcNow;

    /// <summary>
    /// Initializes a new instance of the <see cref="Event"/> class and sets the date of occurrence to the current UTC time.
    /// </summary>
    /// <remarks>
    /// This constructor is protected and intended to be used by derived classes to ensure the 
    /// <see cref="DateOccurred"/> property is initialized to the current UTC time.
    /// </remarks>
    protected Event() => DateOccurred = DateTimeOffset.UtcNow;
}