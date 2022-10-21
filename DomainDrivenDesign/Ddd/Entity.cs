using System.Diagnostics.CodeAnalysis;

namespace DomainDrivenDesign.Ddd;

public abstract class Entity<TIdentity>
{
    protected Entity(TIdentity id)
    {
        ArgumentNullException.ThrowIfNull(id);
        Id = id;
    }

    [NotNull]
    public TIdentity Id { get; }

    public override bool Equals(object? obj)
    {
        return obj is Entity<TIdentity> other
                && GetType() == other.GetType()
                && Id.Equals(other.Id);
    }

    public static bool operator ==(Entity<TIdentity>? a, Entity<TIdentity>? b)
    {
        if (a is null && b is null)
            return true;

        if (a is null || b is null)
            return false;

        return a.Equals(b);
    }

    public static bool operator !=(Entity<TIdentity>? a, Entity<TIdentity>? b)
        => !(a == b);

    public override int GetHashCode()
        => HashCode.Combine(Id, GetType());
}