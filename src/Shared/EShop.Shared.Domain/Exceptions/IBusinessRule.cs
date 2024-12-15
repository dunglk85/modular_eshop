namespace EShop.Shared.Domain.Exceptions;

public interface IBusinessRule
{
    bool IsBroken();

    string Message { get; }
}
