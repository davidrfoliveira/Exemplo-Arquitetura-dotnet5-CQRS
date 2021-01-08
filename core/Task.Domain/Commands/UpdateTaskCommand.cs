using Flunt.Notifications;
using Flunt.Validations;
using System;
using Task.Domain.Commands.Contracts;

namespace Task.Domain.Commands
{
    public class UpdateTaskCommand : Notifiable, ICommand
    {
        public UpdateTaskCommand() { }

        public UpdateTaskCommand(Guid id, string title, string user)
        {
            Id = id;
            Title = title;
            User = user;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string User { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Title, 3, "Title", "Por favor, descreva melhor esta tarefa!")
                    .HasMinLen(User, 6, "User", "Usuário inválido!")
            );
        }
    }
}
