namespace DomainDrivenDesign.Cqrs;

public class CommandNotImplementedException : Exception
{
    public Type CommandType { get; }

    public CommandNotImplementedException(Type commandType)
        : base(message: $"No handler found for command of type {commandType.Name}.")
    {
        CommandType = commandType;
    }
}