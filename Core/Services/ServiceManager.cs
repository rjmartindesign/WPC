using CrimeReporter.Core.Repository;
using CrimeReporter.Core.Services.Interfaces;

namespace CrimeReporter.Services
{
    public class ServiceManager
    {

        public static ICrimeDataService CrimeDataService
        {
            get
            {
                return new CrimeDataService(
                    new CrimeDataRepository()
                );
            }
        }
    }
}
