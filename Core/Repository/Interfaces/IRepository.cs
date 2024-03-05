namespace CrimeReporter.Core.Repository.Interfaces
{
    public interface IRepository<T, Q> where Q : IQuery
    {
        Task<IEnumerable<T>> Get(Q query);
    }
}
