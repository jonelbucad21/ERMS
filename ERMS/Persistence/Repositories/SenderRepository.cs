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
    public class SenderRepository : Repository<Sender>, ISenderRepository
    {
        public SenderRepository(ApplicationDbContext context)
            :base(context)
        {

        }
        public async Task<Sender> Find(int id)
        {
            return await _context.Sender.FindAsync(id);
        }

        public async Task<IEnumerable<Sender>> GetAll()
        {
            return await _context.Sender.ToListAsync();
        }

        public async Task<IEnumerable<Sender>> GetAll(int pageIndex, int pageSize, Expression<Func<Sender, bool>> predicate)
        {
            return await _context.Sender
                .Where(predicate)
                .Skip(pageSize * (pageIndex - 1))
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<int> GetCount()
        {
            return await _context.Sections
                .CountAsync();
        }

        public async Task<int> GetCount(Expression<Func<Sender, bool>> predicate)
        {
            return await _context.Sender
                .CountAsync(predicate);
        }

        public async Task<Sender> SingleOrDefault(Expression<Func<Sender, bool>> predicate)
        {
            return await _context.Sender
                .SingleOrDefaultAsync(predicate);
        }

        public ApplicationDbContext _context
        {
            get { return dbContext as ApplicationDbContext; }
        }
    }
}
