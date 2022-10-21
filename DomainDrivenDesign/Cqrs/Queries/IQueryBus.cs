namespace DomainDrivenDesign.Cqrs;

public interface IQueryBus
{
    Task<TResult> Dispatch<TQuery, TResult>(TQuery query)
        where TQuery : IQuery<TResult>;
}