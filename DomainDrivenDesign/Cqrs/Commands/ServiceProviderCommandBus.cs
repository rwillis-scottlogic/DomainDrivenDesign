using Microsoft.Extensions.DependencyInjection;

namespace DomainDrivenDesign.Cqrs;

public sealed class ServiceProviderCommandBus : ICommandBus
{
    private readonly IServiceProvider Services;

    public ServiceProviderCommandBus(IServiceProvider services)
    {
        Services = services;
    }

    public async Task<TResult> Dispatch<TCommand, TResult>(TCommand command)
        where TCommand : ICommand<TResult>
    {
        var handler = Services.GetService<ICommandHandler<TCommand, TResult>>();

        if (handler is null)
            throw new CommandNotImplementedException(typeof(TCommand));

        return await handler.Handle(command);
    }

    public async Task Dispatch<TCommand>(TCommand command) where TCommand : ICommand
    {
        var handler = Services.GetService<ICommandHandler<TCommand>>();

        if (handler is null)
            throw new CommandNotImplementedException(typeof(TCommand));

        await handler.Handle(command);
    }
}