using DomainDrivenDesign.Cqrs;

namespace DomainDrivenDesign.Example.Domain.Commands;

public sealed record AddFriend(string Name) : ICommand;