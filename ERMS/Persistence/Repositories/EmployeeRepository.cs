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
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {

        public EmployeeRepository(ApplicationDbContext context)
            :base(context)
        {

        }
        public async Task<Employee> Find(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<IEnumerable<Employee>> GetAll(int pageIndex, int pageSize, Expression<Func<Employee, bool>> predicate)
        {
            return await _context.Employees
                .Where(predicate)
                .Skip(pageSize * (pageIndex - 1))
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<int> GetCount()
        {
            return await _context.Employees.CountAsync();
        }

        public async Task<int> GetCount(Expression<Func<Employee, bool>> predicate)
        {
            return await _context.Employees.CountAsync(predicate);
        }

        public async Task<Employee> SingleOrDefault(Expression<Func<Employee, bool>> predicate)
        {
            return await _context.Employees.SingleOrDefaultAsync(predicate);
        }

        public ApplicationDbContext _context
        {
            get { return dbContext as ApplicationDbContext; }
        }
    }
}
