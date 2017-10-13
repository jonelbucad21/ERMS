using ERMS.Data;
using ERMS.Models;
using ERMS.Persistence.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace ERMS.Persistence.Repositories
{
    public class DivisionRepository : Repository<Division>, IDivisionRepository
    {
        public DivisionRepository(ApplicationDbContext context)
            :base(context)
        {

        }

        public async Task<IEnumerable<Division>> GetAll()
        {
            return await _context.Divisions.ToListAsync();
        }

        public async Task<IEnumerable<Division>> GetAll(int pageIndex, int pageSize, Expression<Func<Division, bool>> predicate)
        {
            return await _context.Divisions
                .Where(predicate)
                .Skip(pageSize * (pageSize * (pageIndex - 1)))
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<int> GetCount()
        {
            return await _context.Divisions.CountAsync();
        }

        public async Task<int> GetCount(Expression<Func<Division, bool>> predicate)
        {
            return await _context.Divisions.CountAsync(predicate);
        }

        public async Task<Division> Find(int id)
        {
            return await _context.Divisions.FindAsync(id);
        }

        public async Task<Division> SingleOrDefault(Expression<Func<Division, bool>> predicate)
        {
            return await _context.Divisions.SingleOrDefaultAsync(predicate);
        }

        public ApplicationDbContext _context
        {
            get { return dbContext as ApplicationDbContext; }
        }
    }
}
