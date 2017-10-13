

using ERMS.Persistence.IRepositories;
using System.Threading.Tasks;

namespace ERMS.Persistence
{
    public interface IUnitofWork
    {
        IDepartmentRepository Department { get; }
        IDivisionRepository Division { get;  }
        ILetterRepository Letter { get; }



        Task Commit();
        
    }
}
