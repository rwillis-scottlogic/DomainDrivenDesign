using DomainDrivenDesign.Cqrs;

namespace DomainDrivenDesign.Example.Domain.Queries;

public sealed record SearchFriends(string NameMatch) : IQuery<IEnumerable<FriendDetail>>;