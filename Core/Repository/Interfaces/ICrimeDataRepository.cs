using CrimeReporter.Core.Model;
using CrimeReporter.Core.Model.Query;

namespace CrimeReporter.Core.Repository.Interfaces
{
    public interface ICrimeDataRepository: IRepository<CrimeData, CrimeDataQuery>
    {
    }
}
