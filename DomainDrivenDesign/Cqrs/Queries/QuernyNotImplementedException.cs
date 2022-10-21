namespace DomainDrivenDesign.Cqrs;

public class QueryNotImplementedException : Exception
{
    public Type QueryType { get; }

    public QueryNotImplementedException(Type queryType)
        : base(message: $"No handler found for query of type {queryType.Name}.")
    {
        QueryType = queryType;
    }
}