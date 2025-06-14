![DomAid is a lightweight .NET library that simplifies building clean, maintainable domain layers using DDD principles and the Mediator pattern.](https://github.com/leo-oliveira-eng/DomAid/blob/main/images/logo.png)

# DomAid

DomAid is a lightweight .NET library that simplifies building clean, maintainable domain layers using DDD principles and the Mediator pattern.

## Features
- Domain-Driven Design (DDD) Support: Facilitates the implementation of DDD patterns, including entities, value objects, and domain events.
- Mediator Pattern Integration: Promotes loose coupling between components by implementing the Mediator pattern.
- Infrastructure Abstractions: Provides base classes and interfaces to streamline infrastructure concerns.
- Messaging Support: Includes components to handle messaging within the domain layer.

## Prerequisites
[.NET SDK](https://dotnet.microsoft.com/download) installed on your machine.

## Installation
You can install DomAid via [NuGet](https://www.nuget.org/):

```bash
dotnet add package DomAid
```

## Usage

Here's a basic example of how to use DomAid in your project:

### 1. Entity and Domain Event Example

```csharp
using DomAid.Domain.Entities;
using DomAid.Domain.Events;
using DomAid.Domain.Mediator;

public class Order : Entity
{
    public string OrderNumber { get; private set; }

    public Order(string orderNumber)
    {
        OrderNumber = orderNumber;
        AddDomainEvent(new OrderCreatedEvent(this));
    }
}

public class OrderCreatedEvent : IDomainEvent
{
    public Order Order { get; }

    public OrderCreatedEvent(Order order)
    {
        Order = order;
    }
}
```

- `Entity` is a base class provided by DomAid that includes common entity functionality.
- `IDomainEvent` is an interface for domain events.
- `AddDomainEvent` is a method to register domain events within the entity.

---

### 2. Value Object Example

DomAid encourages the use of value objects for immutable types. Here's a simple value object:

```csharp
using DomAid.Domain.Entities;

public class Money : ValueObject
{
    public decimal Amount { get; }
    public string Currency { get; }

    public Money(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    // Override equality methods as needed
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
    }
}
```

---

### 3. Using the Mediator Pattern

Assume you have implemented a command and a handler. Here is how you might use the mediator to send a command:

```csharp
using DomAid.Mediator.Contracts;
using DomAid.Messaging;

public class CreateOrderCommand : IRequest<Order>
{
    public string OrderNumber { get; set; }
}

public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Order>
{
    public Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = new Order(request.OrderNumber);
        // Save order, raise events, etc.
        return Task.FromResult(order);
    }
}

// Somewhere in your application/service class
public class OrderService
{
    private readonly IMediatorHandler _mediator;

    public OrderService(IMediatorHandler mediator)
    {
        _mediator = mediator;
    }

    public async Task<Order> CreateOrderAsync(string orderNumber)
    {
        var command = new CreateOrderCommand { OrderNumber = orderNumber };
        return await _mediator.SendAsync<CreateOrderCommand, Order>(command);
    }
}
```

---

### 4. Handling Domain Events

You can dispatch domain events using the mediator handler:

```csharp
// Publishing a domain event
await _mediator.PublishAsync(new OrderCreatedEvent(order));
```

---

### 5. Unit of Work and CommandHandler

DomAid provides a base CommandHandler to handle transactional operations:

```csharp
using DomAid.Messaging;
using DomAid.Infrastructure;

public class FakeHandler : CommandHandler
{
    public FakeHandler(IUnitOfWork unitOfWork) : base(unitOfWork) {}

    public async Task<Result> HandleAsync(CommandFake command)
    {
        command.Validate();
        return await CommitAsync();
    }
}
```

---

### 6. Using DomAid's Repository Abstractions

DomAid provides generic repository interfaces to help you keep your domain layer persistence-agnostic and testable:

#### Repository Interfaces

- `IRepository<TEntity>`: Base interface for repositories.
- `IReadRepository<TEntity>`: For read operations (queries).
- `IWriteRepository<TEntity>`: For write operations (commands).

#### Example: Implementing a Repository

```csharp
using DomAid.Entities;
using DomAid.Infrastructure;
using Funcfy.Monads;

public class Order : Entity
{
    public string OrderNumber { get; private set; }
    // ... other properties and methods ...
}

// Example repository for the Order entity
public class OrderRepository : IReadRepository<Order>, IWriteRepository<Order>
{
    private readonly DbContext _context;

    public OrderRepository(DbContext context)
    {
        _context = context;
    }

    // IReadRepository implementation
    public async Task<List<Order>> GetAllAsync()
    {
        return await _context.Set<Order>().ToListAsync();
    }

    public async Task<Maybe<Order>> FindAsync(Guid code)
    {
        var order = await _context.Set<Order>().FindAsync(code);
        return order != null ? Maybe.Some(order) : Maybe.None<Order>();
    }

    public async Task<List<Order>> FindAsync(List<Guid> codes)
    {
        return await _context.Set<Order>().Where(x => codes.Contains(x.Code)).ToListAsync();
    }

    // IWriteRepository implementation
    public async Task AddAsync(Order order)
    {
        await _context.Set<Order>().AddAsync(order);
    }

    public async Task AddAsync(List<Order> orders)
    {
        await _context.Set<Order>().AddRangeAsync(orders);
    }

    public async Task RemoveAsync(Order order)
    {
        _context.Set<Order>().Remove(order);
        await Task.CompletedTask;
    }

    public async Task RemoveAsync(List<Order> orders)
    {
        _context.Set<Order>().RemoveRange(orders);
        await Task.CompletedTask;
    }

    public async Task UpdateAsync(Order order)
    {
        _context.Set<Order>().Update(order);
        await Task.CompletedTask;
    }

    public async Task UpdateAsync(List<Order> orders)
    {
        _context.Set<Order>().UpdateRange(orders);
        await Task.CompletedTask;
    }
}
```

#### Consuming the Repository in Application Logic

```csharp
public class OrderService
{
    private readonly IReadRepository<Order> _readRepository;
    private readonly IWriteRepository<Order> _writeRepository;

    public OrderService(
        IReadRepository<Order> readRepository,
        IWriteRepository<Order> writeRepository)
    {
        _readRepository = readRepository;
        _writeRepository = writeRepository;
    }

    public async Task<List<Order>> ListOrdersAsync()
    {
        return await _readRepository.GetAllAsync();
    }

    public async Task CreateOrderAsync(Order order)
    {
        await _writeRepository.AddAsync(order);
        // Save changes using your unit of work or DbContext, as appropriate
    }
}
```

**Tip:**  
- You can inject `IReadRepository<T>` and `IWriteRepository<T>` separately for better separation of concerns.
- For more methods and documentation, see the interfaces in [`src/DomAid.Domain/Infrastructure`](https://github.com/leo-oliveira-eng/DomAid/tree/main/src/DomAid.Domain/Infrastructure).

---

Let me know if you want this merged into the full README or need a PR!

## Project Structure

- `src/DomAid.Domain`: Contains the core domain logic, including entities, events, infrastructure, mediator, and messaging components.
- `tests/DomAid.Domain.Tests`: Includes unit tests for the domain layer.

## Contributing

Contributions are welcome! Please open an issue or submit a pull request for any improvements or bug fixes.

## License

This project is licensed under the MIT License. See the [LICENSE](https://github.com/leo-oliveira-eng/DomAid/blob/main/LICENSE) file for details.
