using MediatR;

namespace EShop.Shared.Application;

public interface ICommand<out TResult> : IRequest<TResult>
{
    Guid Id { get; }
}

public interface ICommand : IRequest
{
    Guid Id { get; }
}
