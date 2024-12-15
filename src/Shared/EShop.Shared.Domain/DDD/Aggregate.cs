namespace EShop.Shared.Domain.DDD;

public abstract class Aggregate<T> : Entity<T>, IAggregate<T>
{
    private readonly List<DomainEventBase> _domainEvents = new();
    public IReadOnlyList<DomainEventBase> DomainEvents => _domainEvents.ToList();

    public DomainEventBase[] ClearDomainEvents()
    {
        DomainEventBase[] dequeuedEvents = _domainEvents.ToArray();
        _domainEvents.Clear();
        return dequeuedEvents;
    }
}
