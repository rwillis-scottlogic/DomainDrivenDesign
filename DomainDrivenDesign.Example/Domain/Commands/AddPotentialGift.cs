using DomainDrivenDesign.Cqrs;

namespace DomainDrivenDesign.Example.Domain.Commands;

public sealed record AddPotentialGift(Guid FriendId, string Name) : ICommand;