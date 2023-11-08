namespace DevopsDashboardApi.DTOs
{
    public class ResourceUtilizationDTO
    {
        public double CpuPercentage { get; set; }
        public int Id { get; set; }
        public double MemoryPercentage { get; set; }
        public DateTime Timestamp { get; set; }
    }
}