using Funcfy.Monads;

namespace DomAid.Messaging;

/// <summary>
/// Represents an abstract base class for commands that can be validated.
/// </summary>
/// <remarks>
/// Derived classes must implement the <see cref="Validate"/> method to define the specific validation
/// logic for the command. This class serves as a foundation for creating commands that require validation before
/// execution.
/// </remarks>
public abstract class Command
{
    /// <summary>
    /// Validates the current state of the object and determines whether it meets the required conditions.
    /// </summary>
    /// <remarks>
    /// This method is abstract and must be implemented by derived classes to define specific
    /// validation logic.
    /// </remarks>
    /// <returns>
    /// A <see cref="Result"/> object representing the outcome of the validation.  The result indicates whether the
    /// validation was successful and may include error details if validation fails.
    /// </returns>
    public abstract Result Validate();
}
