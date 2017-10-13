using ERMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ERMS.Persistence.IRepositories
{
    public interface ILetterRepository : IRepository<Letter>
    {
        Task<IEnumerable<Letter>> GetAll();
        Task<IEnumerable<Letter>> GetAll(int pageIndex, int pageSize, Expression<Func<Letter, bool>> predicate);
        Task<int> GetCount();
        Task<int> GetCount(Expression<Func<Letter, bool>> predicate);
        Task<Letter> Find(int id);
        Task<Letter> SingleOrDefault(Expression<Func<Letter, bool>> predicate);
    }
}
