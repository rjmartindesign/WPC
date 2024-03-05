using CrimeReporter.Core.Model;
using CrimeReporter.Core.Model.Query;

namespace CrimeReporter.Core.Services.Interfaces
{
    public interface ICrimeDataService
    {
        Task<IEnumerable<CrimeData>> Get(CrimeDataQuery query);
    }
}
