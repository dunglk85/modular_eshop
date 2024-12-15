using System.Runtime.CompilerServices;

namespace EShop.Shared.Domain.ValueObject;

public class PrimitiveValue<T> : IEquatable<PrimitiveValue<T>> where T : struct
{
    public T Value { get; }
    protected PrimitiveValue(T value)
    {
        ArgumentNullException.ThrowIfNull(value, "Value cannot be null!");
        if (!typeof(T).IsPrimitive)
        {
            throw new ArgumentException("T must be a primitive type.");
        }
        Value = value;
    }

    public static PrimitiveValue<T> Of(T value)
    {
        return new PrimitiveValue<T>(value);
    }

    public bool Equals(PrimitiveValue<T>? other)
    {
        return this == other;
    }

    public static bool operator ==(PrimitiveValue<T>? obj1, PrimitiveValue<T>? obj2)
    {
        if (object.Equals(obj1, null))
        {
            if (object.Equals(obj2, null))
            {
                return true;
            }

            return false;
        }

        return obj1.Equals(obj2);
    }

    public static bool operator !=(PrimitiveValue<T>? x, PrimitiveValue<T>? y)
    {
        return !(x == y);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj))
        {
            return false;
        }

        return obj is PrimitiveValue<T> other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }
}
