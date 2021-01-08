using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Task.Domain.Commands;
using Task.Domain.Handlers;
using Task.Domain.Repositories.Contracts;

namespace Task.Api.Controllers
{
    [ApiController]
    [Route("v1/tasks")]
    public class TaskController : ControllerBase
    {
        [Route("")]
        [HttpGet]
        public IEnumerable<Domain.Entities.Task> GetAll(
            [FromServices] ITaskRepository repository
        )
        {
            var user = "david@email.com";

            return repository.GetAll(user);
        }

        [Route("done")]
        [HttpGet]
        public IEnumerable<Domain.Entities.Task> GetAllDone(
            [FromServices] ITaskRepository repository
        )
        {
            var user = "david@email.com";
            return repository.GetAllDone(user);
        }

        [Route("undone")]
        [HttpGet]
        public IEnumerable<Domain.Entities.Task> GetAllUndone(
            [FromServices] ITaskRepository repository
        )
        {
            var user = "david@email.com";
            return repository.GetAllUndone(user);
        }

        [Route("done/today")]
        [HttpGet]
        public IEnumerable<Domain.Entities.Task> GetDoneForToday(
            [FromServices] ITaskRepository repository
        )
        {
            var user = "david@email.com";
            return repository.GetByPeriod(
                user,
                DateTime.Now.Date,
                true
            );
        }

        [Route("undone/today")]
        [HttpGet]
        public IEnumerable<Domain.Entities.Task> GetInactiveForToday(
            [FromServices] ITaskRepository repository
        )
        {
            var user = "david@email.com";
            return repository.GetByPeriod(
                user,
                DateTime.Now.Date,
                false
            );
        }

        [Route("done/tomorrow")]
        [HttpGet]
        public IEnumerable<Domain.Entities.Task> GetDoneForTomorrow(
            [FromServices] ITaskRepository repository
        )
        {
            var user = "david@email.com";
            return repository.GetByPeriod(
                user,
                DateTime.Now.Date.AddDays(1),
                true
            );
        }

        [Route("undone/tomorrow")]
        [HttpGet]
        public IEnumerable<Domain.Entities.Task> GetUndoneForTomorrow(
            [FromServices] ITaskRepository repository
        )
        {
            var user = "david@email.com";
            return repository.GetByPeriod(
                user,
                DateTime.Now.Date.AddDays(1),
                false
            );
        }

        [Route("")]
        [HttpPost]
        public GenericCommandResult Create(
            [FromBody] CreateTaskCommand command,
            [FromServices] TaskHandler handler
        )
        {
            command.User = "david@email.com";

            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpPut]
        public GenericCommandResult Update(
           [FromBody] UpdateTaskCommand command,
           [FromServices] TaskHandler handler
       )
        {
            command.User = "david@email.com";
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("mark-as-done")]
        [HttpPut]
        public GenericCommandResult MarkAsDone(
            [FromBody] MarkTaskAsDoneCommand command,
            [FromServices] TaskHandler handler
        )
        {
            command.User = "david@email.com";
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("mark-as-undone")]
        [HttpPut]
        public GenericCommandResult MarkAsUndone(
            [FromBody] MarkTaskAsUndoneCommand command,
            [FromServices] TaskHandler handler
        )
        {
            command.User = "david@email.com";
            return (GenericCommandResult)handler.Handle(command);
        }
    }
}
