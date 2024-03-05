using CrimeReporter.Model;
using CrimeReporter.Model.Query;
using CrimeReporter.Repository.Interfaces;
using CrimeReporter.Services.Interfaces;

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
