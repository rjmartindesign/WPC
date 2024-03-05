using CrimeReporter.Model;
using CrimeReporter.Model.Query;

namespace CrimeReporter.Services.Interfaces
{
    public interface ICrimeDataService
    {
        Task<IEnumerable<CrimeData>> Get(CrimeDataQuery query);
    }
}
