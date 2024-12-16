using MediatR;

namespace EShop.Shared.Application;

public interface IQuery<out TResult> : IRequest<TResult>;

