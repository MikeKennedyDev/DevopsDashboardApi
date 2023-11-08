namespace DevopsDashboardApi.Models
{
    public class ResourceUtilization
    {
        public double CpuPercentage { get; set; }
        public int Id { get; set; }
        public double MemoryPercentage { get; set; }
        public DateTime Timestamp { get; set; }
    }
}