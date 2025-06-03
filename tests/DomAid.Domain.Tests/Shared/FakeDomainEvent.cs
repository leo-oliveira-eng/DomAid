using DomAid.Events;

namespace DomAid.Domain.Tests.Shared;

public class FakeDomainEvent(Guid aggregateId) : DomainEvent(aggregateId) { }

