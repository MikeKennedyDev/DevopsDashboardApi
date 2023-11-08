namespace DevopsDashboardApi.DTOs
{
    public class ErrorMetricDTO
    {
        public string? ErrorMessage { get; set; }
        public int Id { get; set; }
        public bool IsResolved { get; set; }
        public string? ProjectName { get; set; }
        public string? Severity { get; set; }
        public DateTime Timestamp { get; set; }
    }
}