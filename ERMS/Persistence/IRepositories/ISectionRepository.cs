using ERMS.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ERMS.Persistence.IRepositories
{
    public interface ISectionRepository : IRepository<Section>
    {
        Task<IEnumerable<Section>> GetAll();
        Task<IEnumerable<Section>> GetAll(int pageIndex, int pageSize, Expression<Func<Section, bool>> predicate);
        Task<int> GetCount();
        Task<int> GetCount(Expression<Func<Section, bool>> predicate);
        Task<Section> Find(int id);
        Task<Section> SingleOrDefault(Expression<Func<Section, bool>> predicate);
    }
}
