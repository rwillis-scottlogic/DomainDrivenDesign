using DomainDrivenDesign.Cqrs;

namespace DomainDrivenDesign.Example.Domain.Commands;

public sealed record RenamePotentialGift(Guid FriendId, int PotentialGiftId, string NewName) : ICommand;