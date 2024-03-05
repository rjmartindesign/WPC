namespace CrimeReporter.Core.Model
{
    public class Location
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public Street street { get; set; } = new Street();

    }
}
