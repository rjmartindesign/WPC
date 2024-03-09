using CrimeReporter.Model;
using CrimeReporter.Model.Query;
using CrimeReporter.Repository.Interfaces;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace CrimeReporter.Repository
{
    public class CrimeDataRepository : ICrimeDataRepository
    {
        private string _baseUrl = "https://data.police.uk/api/crimes-street/all-crime";
        public async Task<IEnumerable<CrimeData>> Get(CrimeDataQuery query)
        {
            try
            {
                var uri = String.Format("?lat={0}&lng={1}&date={2}-{3}", query.Lat, query.Long, DateTime.Now.AddYears(-1).Year, query.Month);
                List<CrimeData>? crimeData = new List<CrimeData>();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_baseUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    using (var response = await client.GetAsync(uri))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        crimeData = JsonSerializer.Deserialize<List<CrimeData>>(apiResponse);

                    }
                }
                return crimeData;
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
