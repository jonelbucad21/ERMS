using ERMS.Data;
using ERMS.Persistence.IRepositories;
using ERMS.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace ERMS.Persistence
{
    public class UnitofWork : IUnitofWork
    {
        private readonly ApplicationDbContext _context;

        public IDepartmentRepository Departments { get; set; }
        public IDivisionRepository Divisions { get; set; }
        public ILetterRepository Letters { get; set; }
        public ILetterTypeRepository LetterTypes { get; set; }

        public UnitofWork(ApplicationDbContext context)
        {
            _context = context;
            Departments = new DepartmentRepository(_context);
            Divisions = new DivisionRepository(_context);
            Letters = new LetterRepository(_context);
            LetterTypes = new LetterTypeRepository(_context);
   
        }

        public async Task Commit()
        {
           await _context.SaveChangesAsync();

        }
    }
}
