namespace DevopsDashboardApi.Models
{
    public class Commit
    {
        public string? Author { get; set; }
        public string? Hash { get; set; }
        public int Id { get; set; }
        public string? Message { get; set; }
        public DateTime Timestamp { get; set; }
    }
}