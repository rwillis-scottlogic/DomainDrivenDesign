using DomainDrivenDesign.Example.Domain.Queries;

namespace DomainDrivenDesign.Example.Api.Response;

public sealed record FriendDetailResponse(Guid Id, string Name, IEnumerable<GiftDetailResponse> PotentialGifts)
{
    public static FriendDetailResponse From(FriendDetail friend)
        => new(friend.Id, friend.Name, friend.PotentialGifts.Select(GiftDetailResponse.From));
}