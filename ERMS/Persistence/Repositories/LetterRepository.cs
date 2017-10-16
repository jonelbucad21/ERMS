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
    public class LetterRepository : Repository<Letter>, ILetterRepository
    {
        public LetterRepository(ApplicationDbContext context)
            :base(context)
        {

        }

        public async Task<Letter> Find(int id)
        {
            return await _context.Letters.FindAsync(id);
        }

        public async Task<IEnumerable<Letter>> GetAll()
        {
            return await _context.Letters
                .Include(p => p.LetterType)
                .Include(p => p.Sender)
                .ToListAsync();
        }

        public async Task<IEnumerable<Letter>> GetAll(int pageIndex, int pageSize, Expression<Func<Letter, bool>> predicate)
        {   
            return await _context.Letters
                .Include(p => p.LetterType)
                .Include(p => p.Sender)
                
                .Skip(pageSize * (pageIndex - 1))
                .Take(pageSize)
                .ToListAsync(); 

        }

        public async Task<int> GetCount()
        {
            return await _context.Letters.CountAsync();
        }

        public async Task<int> GetCount(Expression<Func<Letter, bool>> predicate)
        {
            return await _context.Letters.CountAsync(predicate);
        }

        public async Task<Letter> SingleOrDefault(Expression<Func<Letter, bool>> predicate)
        {
            return await _context.Letters
                .Include(p => p.LetterType)
                .Include(p => p.Sender)
                .SingleOrDefaultAsync(predicate);
        }

        public Letter Single(Expression<Func<Letter, bool>> predicate)
        {
            return _context.Letters
                .Include(p => p.LetterType)
                .Include(p => p.Sender)
                .SingleOrDefault(predicate);
        }

        public ApplicationDbContext _context
        {
            get { return dbContext as ApplicationDbContext; }
        }
    }
}
