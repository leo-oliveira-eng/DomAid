using DomAid.Messaging;
using MediatR;

namespace DomAid.Mediator.Contracts;

/// <summary>
/// Defines a contract for handling commands, queries, and events in a mediator pattern.
/// </summary>
/// <remarks>
/// This interface provides methods for sending commands, querying data, and publishing events
/// asynchronously. It is typically used to decouple the sender of a request from its handler, promoting a clean
/// architecture.
/// </remarks>
public interface IMediatorHandler
{
    /// <summary>
    /// Sends the specified command asynchronously and returns the result.
    /// </summary>
    /// <typeparam name="TCommand">The type of the command to send. Must inherit from <see cref="Command"/>.</typeparam>    
    /// <typeparam name="TResult"> The type of the result expected from the command execution.</typeparam>
    /// <param name="command">The command to be sent. Cannot be <see langword="null"/>.</param>
    /// <param name="cancellationToken">Used to cancel the asynchronous operation</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the response object.</returns>
    Task<TResult> SendAsync<TCommand, TResult>(TCommand command, CancellationToken cancellationToken = default)
        where TCommand : IRequest<TResult> 
        where TResult : class;

    /// <summary>
    /// Executes the specified query asynchronously and returns the result.
    /// </summary>
    /// <typeparam name="TQuery">The type of the query to execute. Must inherit from <see cref="Query"/>.</typeparam>
    /// <typeparam name="TResult">The type of the result expected from the query execution.</typeparam>
    /// <param name="query">The query to execute. Cannot be <see langword="null"/>.</param>
    /// <param name="cancellationToken">Used to cancel the asynchronous operation</param>
    /// <returns> 
    /// A task that represents the asynchronous operation. The task result contains the query result as an <see cref="object"/>.
    /// </returns>
    Task<TResult> QueryAsync<TQuery, TResult>(TQuery query, CancellationToken cancellationToken = default) 
        where TQuery : IRequest<TResult>
        where TResult : class;

    /// <summary>
    /// Publishes the specified event asynchronously to all registered subscribers.
    /// </summary>
    /// <typeparam name="TNotification">The type of the event to publish.</typeparam>
    /// <param name="notification">The event instance to be published. Cannot be <see langword="null"/>.</param>
    /// <param name="cancellationToken">Used to cancel the asynchronous operation</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task PublishAsync<TNotification>(TNotification notification, CancellationToken cancellationToken = default)
        where TNotification : INotification;
}
