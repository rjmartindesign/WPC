using CrimeReporter.Repository;
using CrimeReporter.Services.Interfaces;

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
