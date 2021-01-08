using System;
using System.Collections.Generic;


namespace Task.Domain.Repositories.Contracts
{
    public interface ITaskRepository
    {
        void Create(Entities.Task todo);
        void Update(Entities.Task todo);
        Entities.Task GetById(Guid id, string user);
        IEnumerable<Entities.Task> GetAll(string user);
        IEnumerable<Entities.Task> GetAllDone(string user);
        IEnumerable<Entities.Task> GetAllUndone(string user);
        IEnumerable<Entities.Task> GetByPeriod(string user, DateTime date, bool done);
    }
}
