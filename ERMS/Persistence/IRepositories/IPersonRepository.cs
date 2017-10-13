using ERMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ERMS.Persistence.IRepositories
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAll();
        Task<IEnumerable<Person>> GetAll(int pageIndex, int pageSize, Expression<Func<Person, bool>> predicate);
        Task<int> GetCount();
        Task<int> GetCount(Expression<Func<Person, bool>> predicate);
        Task<Person> Find(int id);
        Task<Person> SingleOrDefault(Expression<Func<Person, bool>> predicate);
    }
}
