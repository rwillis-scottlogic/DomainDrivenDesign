namespace DomainDrivenDesign.Cqrs;

public interface ICommandBus
{
    Task<TResult> Dispatch<TCommand, TResult>(TCommand command)
        where TCommand : ICommand<TResult>;
    
    Task Dispatch<TCommand>(TCommand command)
        where TCommand : ICommand;
}
