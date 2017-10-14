using ERMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ERMS.Persistence.IRepositories
{
    public interface ISenderRepository : IRepository<Sender>
    {
        Task<IEnumerable<Sender>> GetAll();
        Task<IEnumerable<Sender>> GetAll(int pageIndex, int pageSize, Expression<Func<Sender, bool>> predicate);
        Task<int> GetCount();
        Task<int> GetCount(Expression<Func<Sender, bool>> predicate);
        Task<Sender> Find(int id);
        Task<Sender> SingleOrDefault(Expression<Func<Sender, bool>> predicate);
    }
}
