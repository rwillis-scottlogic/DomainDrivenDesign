using DomainDrivenDesign.Example.Domain.Queries;

namespace DomainDrivenDesign.Example.Api.Response;

public sealed record GiftDetailResponse(int Id, string Name)
{
    public static GiftDetailResponse From(GiftDetail gift) => new(gift.Id, gift.Name);
}