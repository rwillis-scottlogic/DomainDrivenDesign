using DomainDrivenDesign.Ddd;

namespace DomainDrivenDesign.Example.Domain.Types;

public sealed class FriendName : Value
{
    public FriendName(string value)
    {
        // This is not a good way to do validation!
        // But that's a non-trivial problem in DDD.
        // To be continued...
        
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Name cannot be empty.");

        if (value.Length > 100)
            throw new ArgumentException("Name must not be longer than 100 characters.");
        
        Value = value;
    }
    
    public string Value { get; }
    
    protected override IEnumerable<object?> EqualityComponents => new object[] { Value };

    public override string ToString() => Value.ToString();
}