namespace DevopsDashboardApi.DTOs
{
    public class DeploymentDTO
    {
        public DateTime DeployedAt { get; set; }
        public string? Environment { get; set; }
        public int Id { get; set; }
        public string? ProjectName { get; set; }
        public string? Status { get; set; }
        public string? Version { get; set; }
    }
}