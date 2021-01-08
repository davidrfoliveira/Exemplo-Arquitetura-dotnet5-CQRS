using Flunt.Notifications;
using Task.Domain.Commands;
using Task.Domain.Commands.Contracts;
using Task.Domain.Handlers.Contracts;
using Task.Domain.Repositories.Contracts;

namespace Task.Domain.Handlers
{
    public class TaskHandler :
          Notifiable,
          IHandler<CreateTaskCommand>,
          IHandler<UpdateTaskCommand>,
          IHandler<MarkTaskAsDoneCommand>,
          IHandler<MarkTaskAsUndoneCommand>
    {
        private readonly ITaskRepository _repository;

        public TaskHandler(ITaskRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateTaskCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

            // Gera o TodoItem
            var task = new Entities.Task(command.Title, command.User, command.Date);

            // Salva no banco
            _repository.Create(task);

            // Retorna o resultado
            return new GenericCommandResult(true, "Tarefa salva", task);
        }

        public ICommandResult Handle(UpdateTaskCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

            // Recupera o TodoItem (Rehidratação)
            var task = _repository.GetById(command.Id, command.User);

            // Altera o título
            task.UpdateTitle(command.Title);

            // Salva no banco
            _repository.Update(task);

            // Retorna o resultado
            return new GenericCommandResult(true, "Tarefa salva", task);
        }

        public ICommandResult Handle(MarkTaskAsDoneCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

            // Recupera o TodoItem
            var task = _repository.GetById(command.Id, command.User);

            // Altera o estado
            task.MarkAsDone();

            // Salva no banco
            _repository.Update(task);

            // Retorna o resultado
            return new GenericCommandResult(true, "Tarefa salva", task);
        }

        public ICommandResult Handle(MarkTaskAsUndoneCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

            // Recupera o TodoItem
            var task = _repository.GetById(command.Id, command.User);

            // Altera o estado
            task.MarkAsUndone();

            // Salva no banco
            _repository.Update(task);

            // Retorna o resultado
            return new GenericCommandResult(true, "Tarefa salva", task);
        }
    }
}
