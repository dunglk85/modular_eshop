using MediatR;

namespace EShop.Shared.Domain.DDD;

public abstract class DomainEventBase : INotification
{
    public Guid Id { get; } = Guid.NewGuid();
    public DateTime OccurredOn { get; } = DateTime.UtcNow;
}