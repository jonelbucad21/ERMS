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
    public class SectionRepository : Repository<Section>, ISectionRepository, IDisposable
    {
        public SectionRepository(ApplicationDbContext context)
            :base(context)
        {

        }

        public async Task<Section> Find(int id)
        {
            return await _context.Sections.FindAsync(id);
        }

        public async Task<IEnumerable<Section>> GetAll()
        {
            return await _context.Sections.ToListAsync();
        }

        public async Task<IEnumerable<Section>> GetAll(int pageIndex, int pageSize, Expression<Func<Section, bool>> predicate)
        {
            return await _context.Sections
                .Where(predicate)
                .Skip(pageSize * (pageIndex - 1))
                .Skip(pageSize).ToListAsync();
        }

        public async Task<int> GetCount()
        {
            return await _context.Sections.CountAsync();
        }

        public async Task<int> GetCount(Expression<Func<Section, bool>> predicate)
        {
            return await _context.Sections.CountAsync(predicate);
        }

        public async Task<Section> SingleOrDefault(Expression<Func<Section, bool>> predicate)
        {
            return await _context.Sections.SingleOrDefaultAsync(predicate);
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public ApplicationDbContext _context
        {
            get { return dbContext as ApplicationDbContext; }
        }
    }
}
