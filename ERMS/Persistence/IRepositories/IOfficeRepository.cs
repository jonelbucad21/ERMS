using ERMS.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ERMS.Persistence.IRepositories
{
    public interface IOfficeRepository : IRepository<Office>
    {
        Task<IEnumerable<Office>> GetAll();
        Task<IEnumerable<Office>> GetAll(int pageIndex, int pageSize, Expression<Func<Office, bool>> predicate);
        Task<int> GetCount();
        Task<int> GetCount(Expression<Func<Office,bool>> predicate);
        Task<Office> Find(int id);
        Task<Office> SingleOrDefault(Expression<Func<Office, bool>> predicate);
    }

}
