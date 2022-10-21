using DomainDrivenDesign.Ddd;

namespace DomainDrivenDesign.Example.Domain.Events;

public sealed record GiftRenamed(int giftId, string giftName) : IDomainEvent;