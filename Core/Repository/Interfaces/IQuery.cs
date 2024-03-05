namespace CrimeReporter.Core.Repository.Interfaces
{
    public interface IQuery
    {
        public int Month { get;set; }
        public double Lat { get; set; }
        public double Long { get; set; }
    }
}
