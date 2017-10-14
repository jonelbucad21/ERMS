

using ERMS.Persistence.IRepositories;
using System.Threading.Tasks;

namespace ERMS.Persistence
{
    public interface IUnitofWork
    {
        IDepartmentRepository Departments { get; }
        IDivisionRepository Divisions { get;  }
        ILetterRepository Letters { get; }
        ILetterTypeRepository LetterTypes { get;  }



        Task Commit();
        
    }
}
