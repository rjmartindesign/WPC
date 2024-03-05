using CrimeReporter.API.Model.Query;

namespace CrimeReporter.Repository.Interfaces
{
    public interface IRepository<T, Q> where Q : IQuery
    {
        Task<IEnumerable<T>> Get(Q query);
    }
}
