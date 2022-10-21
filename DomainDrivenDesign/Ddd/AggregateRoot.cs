namespace DomainDrivenDesign.Ddd;

public abstract class AggregateRoot<TIdentity> : Entity<TIdentity>
{
    protected AggregateRoot(TIdentity id) : base(id) { }

    private readonly Queue<IDomainEvent> EventQueue = new();

    public IEnumerable<IDomainEvent> Events => EventQueue;

    protected void PublishEvent(IDomainEvent @event) => EventQueue.Enqueue(@event);
}