namespace CrimeReporter.Model
{
    public class Location
    {
        public string latitude { get; set; } = String.Empty;
        public string longitude { get; set; } = String.Empty;
        public Street street { get; set; } = new Street();

    }
}
