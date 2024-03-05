namespace CrimeReporter.Model
{
    public class CrimeData
    {
        public int id { get; set; }
        public string category { get; set; } = String.Empty;
        public string location_type { get; set; } = String.Empty;
        public Location location { get; set; } = new Location();
        public string context { get; set; } = string.Empty;
        public Object? outcome_status { get; set; }
        public string persistent_id { get; set; } = string.Empty;
        public string location_subtype { get; set; } = string.Empty;
        public string month { get; set; } = string.Empty;
    }
}
