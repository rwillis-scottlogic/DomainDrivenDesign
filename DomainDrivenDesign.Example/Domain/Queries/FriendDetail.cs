namespace DomainDrivenDesign.Example.Domain.Queries;

public sealed record FriendDetail(
    Guid Id,
    string Name,
    IEnumerable<GiftDetail> PotentialGifts);