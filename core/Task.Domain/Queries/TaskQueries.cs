using System;
using System.Linq.Expressions;

namespace Task.Domain.Queries
{
    public static class TaskQueries
    {
        public static Expression<Func<Entities.Task, bool>> GetAll(string user)
        {
            return x => x.User == user;
        }

        public static Expression<Func<Entities.Task, bool>> GetAllDone(string user)
        {
            return x => x.User == user && x.Done == true;
        }

        public static Expression<Func<Entities.Task, bool>> GetAllUndone(string user)
        {
            return x => x.User == user && x.Done == false;
        }

        public static Expression<Func<Entities.Task, bool>> GetByPeriod(string user, DateTime date, bool done)
        {
            return x =>
                x.User == user &&
                x.Done == done &&
                x.Date.Date == date.Date;
        }
    }
}
