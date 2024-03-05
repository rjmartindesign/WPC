namespace CrimeReporter.Core.Model
{
    public class ApiResponse
    {
        public object? Result { get; set; }
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
    }
}
