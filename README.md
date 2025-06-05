<p align="center">
      <img  
        alt="DomAid is a lightweight .NET library that simplifies building clean, maintainable domain layers using DDD principles and the Mediator pattern." 
        src="https://github.com/leo-oliveira-eng/DomAid/blob/main/images/logo.png"
        height="400px"
      />
</p>

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

In this example:

- `Entity` is a base class provided by DomAid that includes common entity functionality.

- `IDomainEvent` is an interface for domain events.

- `AddDomainEvent` is a method to register domain events within the entity.

## Project Structure

- `src/DomAid.Domain`: Contains the core domain logic, including entities, events, infrastructure, mediator, and messaging components.

- `tests/DomAid.Domain.Tests`: Includes unit tests for the domain layer.

## Contributing

Contributions are welcome! Please open an issue or submit a pull request for any improvements or bug fixes.

## License

This project is licensed under the MIT License. See the [LICENSE](https://github.com/leo-oliveira-eng/DomAid/blob/main/LICENSE) file for details.