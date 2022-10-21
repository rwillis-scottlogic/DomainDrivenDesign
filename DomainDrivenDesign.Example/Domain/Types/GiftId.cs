using DomainDrivenDesign.Ddd;

namespace DomainDrivenDesign.Example.Domain.Types;

public sealed class GiftId : Value
{
    public GiftId(int value)
    {
        Value = value;
    }
    
    public int Value { get; }
    
    protected override IEnumerable<object?> EqualityComponents => new object[] { Value };

    public override string ToString() => Value.ToString();
}