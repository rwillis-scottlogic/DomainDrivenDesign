using DomainDrivenDesign.Ddd;

namespace DomainDrivenDesign.Example.Domain.Types;

public sealed class FriendId : Value
{
    public FriendId(Guid value)
    {
        Value = value;
    }
    
    public Guid Value { get; }
    
    protected override IEnumerable<object?> EqualityComponents => new object[] { Value };

    public override string ToString() => Value.ToString();
}