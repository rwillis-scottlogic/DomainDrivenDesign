using DomainDrivenDesign.Ddd;
using DomainDrivenDesign.Example.Domain.Events;

namespace DomainDrivenDesign.Example.Domain.Types;

public sealed class Friend : AggregateRoot<FriendId>
{
    public static Friend New(FriendName name)
    {
        var friend = new Friend(new FriendId(Guid.Empty), name);
        friend.PublishEvent(new FriendAdded());
        return friend;
    }

    public static Friend From(FriendSnapshot snapshot)
        => new Friend(
            new FriendId(snapshot.Id),
            new FriendName(snapshot.Name));
    
    private Friend(FriendId id, FriendName name) : base(id)
    {
        Name = name;
    }
    
    public FriendName Name { get; private set; }

    public void RenameTo(FriendName name)
    {
        if (Name == name)
            return;

        Name = name;
        PublishEvent(new FriendRenamed(Id.Value, name.Value));
    }

    private List<Gift> _potentialGifts = new();

    public IEnumerable<Gift> PotentialGifts => _potentialGifts;

    public void AddPotentialGift(Gift gift)
    {
        _potentialGifts.Add(gift);
        gift.OnChange += PublishEvent;
        PublishEvent(new GiftAdded(gift.Name.Value));
    }

    public FriendSnapshot Snapshot() => new FriendSnapshot(
        Id.Value,
        Name.Value,
        PotentialGifts.Select(gift => gift.Snapshot()));
}