using ERMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ERMS.Persistence.IRepositories
{
    public interface ILetterTypeRepository : IRepository<LetterType>
    {
        Task<IEnumerable<LetterType>> GetAll();
        Task<IEnumerable<LetterType>> GetAll(int pageIndex, int pageSize, Expression<Func<LetterType, bool>> predicate);
        Task<int> GetCount();
        Task<int> GetCount(Expression<Func<LetterType, bool>> predicate);
        Task<LetterType> Find(int id);
        Task<LetterType> SingleOrDefault(Expression<Func<LetterType, bool>> predicate);
    }
}
