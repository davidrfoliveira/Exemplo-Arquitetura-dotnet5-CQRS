using Flunt.Notifications;
using Flunt.Validations;
using System;
using Task.Domain.Commands.Contracts;

namespace Task.Domain.Commands
{
    public class CreateTaskCommand : Notifiable, ICommand
    {
        public CreateTaskCommand() { }

        public CreateTaskCommand(string title, string user, DateTime date)
        {
            Title = title;
            User = user;
            Date = date;
        }

        public string Title { get; set; }
        public string User { get; set; }
        public DateTime Date { get; set; }

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

