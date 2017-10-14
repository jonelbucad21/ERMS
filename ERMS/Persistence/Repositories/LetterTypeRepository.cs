using ERMS.Models;
using ERMS.Persistence.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using ERMS.Data;
using Microsoft.EntityFrameworkCore;

namespace ERMS.Persistence.Repositories
{
    public class LetterTypeRepository : Repository<LetterType>, ILetterTypeRepository
    {
        public LetterTypeRepository(ApplicationDbContext context)
            :base(context)
        {

        }

        public async Task<LetterType> Find(int id)
        {
            return await _context.LetterTypes.FindAsync(id);
        }

        public async Task<IEnumerable<LetterType>> GetAll()
        {
            return await _context.LetterTypes.ToListAsync();
        }

        public async Task<IEnumerable<LetterType>> GetAll(int pageIndex, int pageSize, Expression<Func<LetterType, bool>> predicate)
        {
            return await _context.LetterTypes
                .Where(predicate)
                .Skip(pageSize * (pageIndex - 1))
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<int> GetCount()
        {
            return await _context.LetterTypes.CountAsync();
        }

        public async Task<int> GetCount(Expression<Func<LetterType, bool>> predicate)
        {
            return await _context.LetterTypes.CountAsync(predicate);
        }

        public async Task<LetterType> SingleOrDefault(Expression<Func<LetterType, bool>> predicate)
        {
            return await _context.LetterTypes.SingleOrDefaultAsync(predicate);
        }

        public ApplicationDbContext _context
        {
            get { return dbContext as ApplicationDbContext; }
        }
    }
}
