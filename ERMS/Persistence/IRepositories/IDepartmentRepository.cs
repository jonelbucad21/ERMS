using ERMS.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ERMS.Persistence.IRepositories
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        Task<IEnumerable<Department>> GetAll();
        Task<IEnumerable<Department>> GetAll(int pageIndex, int pageSize, Expression<Func<Department, bool>> predicate);
        Task<int> GetCount();
        Task<int> GetCount(Expression<Func<Department, bool>> predicate);
        Task<Department> Find(int id);
        Task<Department> SingleOrDefault(Expression<Func<Department, bool>> predicate);
    }
}
