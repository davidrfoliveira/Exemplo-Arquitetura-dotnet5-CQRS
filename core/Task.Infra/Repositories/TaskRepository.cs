using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task.Domain.Queries;
using Task.Domain.Repositories.Contracts;
using Task.Infra.Contexts;

namespace Task.Infra.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(Domain.Entities.Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public IEnumerable<Domain.Entities.Task> GetAll(string user)
        {
            return _context.Tasks
               .AsNoTracking()
               .Where(TaskQueries.GetAll(user))
               .OrderBy(x => x.Date);
        }

        public IEnumerable<Domain.Entities.Task> GetAllDone(string user)
        {
            return _context.Tasks
                .AsNoTracking()
                .Where(TaskQueries.GetAllDone(user))
                .OrderBy(x => x.Date);
        }

        public IEnumerable<Domain.Entities.Task> GetAllUndone(string user)
        {
            return _context.Tasks
                .AsNoTracking()
                .Where(TaskQueries.GetAllUndone(user))
                .OrderBy(x => x.Date);
        }

        public Domain.Entities.Task GetById(Guid id, string user)
        {
            return _context
                .Tasks
                .FirstOrDefault(x => x.Id == id && x.User == user);
        }

        public IEnumerable<Domain.Entities.Task> GetByPeriod(string user, DateTime date, bool done)
        {
            return _context.Tasks
                .AsNoTracking()
                .Where(TaskQueries.GetByPeriod(user, date, done))
                .OrderBy(x => x.Date);
        }

        public void Update(Domain.Entities.Task task)
        {
            _context.Entry(task).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
