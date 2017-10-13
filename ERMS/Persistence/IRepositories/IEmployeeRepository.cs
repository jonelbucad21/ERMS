using ERMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ERMS.Persistence.IRepositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAll();
        Task<IEnumerable<Employee>> GetAll(int pageIndex, int pageSize, Expression<Func<Employee, bool>> predicate);
        Task<int> GetCount();
        Task<int> GetCount(Expression<Func<Employee, bool>> predicate);
        Task<Employee> Find(int id);
        Task<Employee> SingleOrDefault(Expression<Func<Employee, bool>> predicate);
    }
}
