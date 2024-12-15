namespace EShop.Shared.Domain.DDD;

public interface IAggregate<T> : IAggregate, IEntity<T>;

public interface IAggregate : IEntity
{
    IReadOnlyList<DomainEventBase> DomainEvents { get; }
    DomainEventBase[] ClearDomainEvents();
}
