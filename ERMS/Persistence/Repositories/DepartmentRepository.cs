using ERMS.Data;
using ERMS.Models;
using ERMS.Persistence.IRepositories;
using ERMS.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace ERMS.Persistence.Repositories
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {

        public DepartmentRepository(ApplicationDbContext context)
            :base(context)
        {

        }

        public async Task<IEnumerable<Department>> GetAll()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<Department> Find(int id)
        {
            return await _context.Departments.FindAsync(id);
        }

        public async Task<Department> SingleOrDefault(Expression<Func<Department,bool>> predicate)
        {
            return await _context.Departments
                .SingleOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<Department>> GetAll(int pageIndex, int pageSize, Expression<Func<Department, bool>> predicate)
        {
            return await _context.Departments
                .Where(predicate)
                .Skip(pageSize * (pageIndex - 1))
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<int> GetCount()
        {
            return await _context.Departments.CountAsync();
        }

        public async Task<int> GetCount(Expression<Func<Department, bool>> predicate)
        {
            return await _context.Departments.CountAsync(predicate);
        }

        public ApplicationDbContext _context
        {
            get { return dbContext as ApplicationDbContext; }
        }
    }
}
