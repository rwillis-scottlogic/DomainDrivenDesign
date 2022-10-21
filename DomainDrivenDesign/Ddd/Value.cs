namespace DomainDrivenDesign.Ddd;

public abstract class Value
{
    protected abstract IEnumerable<object?> EqualityComponents { get; }

    public override bool Equals(object? obj)
        => obj is Value other
           && GetType() == obj.GetType()
           && EqualityComponents.SequenceEqual(other.EqualityComponents);

    public static bool operator ==(Value? a, Value? b)
    {
        if (a is null && b is null)
            return true;

        if (a is null || b is null)
            return false;

        return a.Equals(b);
    }

    public static bool operator !=(Value? a, Value? b)
        => !(a == b);

    public override int GetHashCode()
        => EqualityComponents.Aggregate(1, HashCode.Combine);
} 