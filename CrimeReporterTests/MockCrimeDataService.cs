using CrimeReporter.Model.Query;
using CrimeReporter.Model;
using CrimeReporter.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimeReporterTests
{
    public class MockCrimeDataService : ICrimeDataService
    {
        private readonly bool _exceptionThrown;

        public MockCrimeDataService(bool exceptionThrown = false)
        {
            _exceptionThrown = exceptionThrown;
        }

        public async Task<IEnumerable<CrimeData>> Get(CrimeDataQuery query)
        {
            if (_exceptionThrown)
            {
                throw new Exception("Simulated exception for testing");
            }

            return await Task.FromResult<IEnumerable<CrimeData>>(new List<CrimeData>());
        }

    }
}
