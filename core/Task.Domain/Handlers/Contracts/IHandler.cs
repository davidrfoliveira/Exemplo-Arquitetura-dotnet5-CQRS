using Task.Domain.Commands.Contracts;

namespace Task.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
