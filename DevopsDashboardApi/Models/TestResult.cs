namespace DevopsDashboardApi.Models
{
    public class TestResult
    {
        public string? Details { get; set; }
        public int Id { get; set; }
        public bool Passed { get; set; }
        public string? ProjectName { get; set; }
        public string? TestName { get; set; }
        public DateTime Timestamp { get; set; }
    }
}