namespace DevopsDashboardApi.Models
{
    public class Build
    {
        #region Parameters

        public string? Branch { get; set; }
        public string? Duration { get; set; }
        public int Id { get; set; }
        public string? ProjectName { get; set; }
        public DateTime StartTime { get; set; }
        public string? Status { get; set; }

        #endregion Parameters
    }
}