using ERMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ERMS.Persistence.IRepositories
{
    public interface IDivisionRepository : IRepository<Division>
    {
        Task<IEnumerable<Division>> GetAll();
        Task<IEnumerable<Division>> GetAll(int pageIndex, int pageSize, Expression<Func<Division, bool>> predicate);
        Task<int> GetCount();
        Task<int> GetCount(Expression<Func<Division, bool>> predicate);
        Task<Division> Find(int id);
        Task<Division> SingleOrDefault(Expression<Func<Division, bool>> predicate);
    }
}
