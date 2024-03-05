using CrimeReporter.Core.Model;
using CrimeReporter.Core.Model.Query;
using CrimeReporter.Core.Repository.Interfaces;
using CrimeReporter.Core.Services.Interfaces;

namespace CrimeReporter.Services
{
    public class CrimeDataService : ICrimeDataService
    {
        private ICrimeDataRepository _crimeDataRepository;

        public CrimeDataService(ICrimeDataRepository crimeDataRepository)
        {
            this._crimeDataRepository = crimeDataRepository;
        }
        public Task<IEnumerable<CrimeData>> Get(CrimeDataQuery query)
        {
            return _crimeDataRepository.Get(query);
        }
    }
}
