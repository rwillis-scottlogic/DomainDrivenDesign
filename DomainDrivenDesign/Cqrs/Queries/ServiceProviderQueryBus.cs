using Microsoft.Extensions.DependencyInjection;

namespace DomainDrivenDesign.Cqrs;

public sealed class ServiceProviderQueryBus : IQueryBus
{
    private readonly IServiceProvider Services;

    public ServiceProviderQueryBus(IServiceProvider services)
    {
        Services = services;
    }

    public async Task<TResult> Dispatch<TQuery, TResult>(TQuery query)
        where TQuery : IQuery<TResult>
    {
        var handler = Services.GetService<IQueryHandler<TQuery, TResult>>();

        if (handler is null)
            throw new QueryNotImplementedException(typeof(TQuery));

        return await handler.Handle(query);
    }
}