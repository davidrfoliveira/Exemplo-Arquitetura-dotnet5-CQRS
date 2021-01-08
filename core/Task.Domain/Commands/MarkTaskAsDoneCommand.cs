using Flunt.Notifications;
using Flunt.Validations;
using System;
using Task.Domain.Commands.Contracts;

namespace Task.Domain.Commands
{
    public class MarkTaskAsDoneCommand : Notifiable, ICommand
    {
        public MarkTaskAsDoneCommand() { }

        public MarkTaskAsDoneCommand(Guid id, string user)
        {
            Id = id;
            User = user;
        }

        public Guid Id { get; set; }
        public string User { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(User, 6, "User", "Usuário inválido!")
            );
        }
    }
}
