using DomainDrivenDesign.Cqrs;

namespace DomainDrivenDesign.Example.Domain.Queries;

public sealed record FindSpecificFriend(Guid Id) : IQuery<FriendDetail?>;