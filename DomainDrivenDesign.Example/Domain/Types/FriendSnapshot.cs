namespace DomainDrivenDesign.Example.Domain.Types;

public sealed record FriendSnapshot(
    Guid Id,
    string Name,
    IEnumerable<GiftSnapshot> PotentialGifts);