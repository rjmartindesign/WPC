using CrimeReporter.API.Model.Query;

namespace CrimeReporter.Model.Query
{
    public class CrimeDataQuery : IQuery
    {
        public int Month { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
    }
}
