namespace DevopsDashboardApi.Models
{
    public class PerformanceMetric
    {
        public TimeSpan BuildDuration { get; set; }
        public int Id { get; set; }
        public string? ProjectName { get; set; }
        public double TestPassPercentage { get; set; }
        public DateTime Timestamp { get; set; }
    }
}