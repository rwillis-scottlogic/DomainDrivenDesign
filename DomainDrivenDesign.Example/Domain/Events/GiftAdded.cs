using DomainDrivenDesign.Ddd;

namespace DomainDrivenDesign.Example.Domain.Events;

public sealed record GiftAdded(string name) : IDomainEvent;