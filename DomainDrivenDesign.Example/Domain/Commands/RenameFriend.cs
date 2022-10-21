using DomainDrivenDesign.Cqrs;

namespace DomainDrivenDesign.Example.Domain.Commands;

public sealed record RenameFriend(Guid FriendId, string NewName) : ICommand;