using CrimeReporter.Model;
using CrimeReporter.Model.Query;

namespace CrimeReporter.Repository.Interfaces
{
    public interface ICrimeDataRepository: IRepository<CrimeData, CrimeDataQuery>
    {
    }
}
