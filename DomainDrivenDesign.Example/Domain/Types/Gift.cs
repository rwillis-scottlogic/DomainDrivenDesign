using DomainDrivenDesign.Ddd;
using DomainDrivenDesign.Example.Domain.Events;

namespace DomainDrivenDesign.Example.Domain.Types;

public sealed class Gift : Entity<GiftId>
{
    public static Gift New(GiftName name)
        => new Gift(new GiftId(0), name);

    public static Gift From(GiftSnapshot snapshot)
        => new Gift(
            new GiftId(snapshot.Id),
            new GiftName(snapshot.Name));

    private Gift(GiftId id, GiftName name) : base(id)
    {
        Name = name;
    }
    
    internal event Action<IDomainEvent> OnChange = _ => { };

    public GiftName Name { get; private set; }

    public void RenameTo(GiftName name)
    {
        if (Name == name)
            return;

        Name = name;
        OnChange(new GiftRenamed(Id.Value, name.Value));
    }

    public GiftSnapshot Snapshot() => new GiftSnapshot(Id.Value, Name.Value);
}