using CrimeReporter.Core.Repository.Interfaces;

namespace CrimeReporter.Core.Model.Query
{
    public class CrimeDataQuery : IQuery
    {
        public int Month { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
    }
}
