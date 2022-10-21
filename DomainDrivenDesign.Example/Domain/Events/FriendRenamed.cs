using DomainDrivenDesign.Ddd;

namespace DomainDrivenDesign.Example.Domain.Events;

public sealed record FriendRenamed(Guid FriendId, string Name) : IDomainEvent;
