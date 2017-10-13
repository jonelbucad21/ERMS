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

        public IDepartmentRepository Department { get; set; }
        public IDivisionRepository Division { get; set; }
        public ILetterRepository Letter { get; set; }

        public UnitofWork(ApplicationDbContext context)
        {
            _context = context;
      //      _context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
            Department = new DepartmentRepository(_context);
            Division = new DivisionRepository(_context);
            Letter = new LetterRepository(_context);
   
        }

        public async Task Commit()
        {
           await _context.SaveChangesAsync();

        }
    }
}
