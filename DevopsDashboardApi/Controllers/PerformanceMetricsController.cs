using DevopsDashboardApi.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevopsDashboardApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerformanceMetricsController : ControllerBase
    {
        #region Fields

        private List<PerformanceMetricDTO> _performanceMetrics = new List<PerformanceMetricDTO>
        {
            new PerformanceMetricDTO{ Id=1, BuildDuration=new TimeSpan(0, 0, 10), ProjectName="Test proj 1", TestPassPercentage=1.0, Timestamp=DateTime.Now },
            new PerformanceMetricDTO{ Id=2, BuildDuration=new TimeSpan(0, 0, 15), ProjectName="Test proj 2", TestPassPercentage=2.0, Timestamp=DateTime.Now },
            new PerformanceMetricDTO{ Id=3, BuildDuration=new TimeSpan(0, 1, 0), ProjectName="Test proj 3", TestPassPercentage=3.0, Timestamp=DateTime.Now },
        };

        #endregion Fields

        #region Endpoints

        [HttpPost]
        public IActionResult CreatePerformanceMetric([FromBody] PerformanceMetricDTO performanceMetric)
        {
            if (performanceMetric == null)
            {
                return BadRequest();
            }
            _performanceMetrics.Add(performanceMetric);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePerformanceMetric(int id)
        {
            var performanceMetric = _performanceMetrics.Find(o => o.Id == id);
            if (performanceMetric == null)
            {
                return NotFound();
            }
            _performanceMetrics.Remove(performanceMetric);

            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetPerformanceMetricById(int id)
        {
            var performanceMetric = _performanceMetrics.Find(o => o.Id == id);
            if (performanceMetric == null)
            {
                return NotFound();
            }
            return Ok(performanceMetric);
        }

        [HttpGet]
        public IActionResult GetPerformanceMetrics()
        {
            return Ok(_performanceMetrics);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePerformanceMetric(int id, [FromBody] PerformanceMetricDTO performanceMetricDTO)
        {
            if (performanceMetricDTO == null || performanceMetricDTO.Id != id)
            {
                return BadRequest();
            }

            var performanceMetric = _performanceMetrics.Find(o => o.Id == id);
            if (performanceMetric == null)
            {
                return NotFound();
            }

            performanceMetric.BuildDuration = performanceMetricDTO.BuildDuration;
            performanceMetric.ProjectName = performanceMetricDTO.ProjectName;
            performanceMetric.TestPassPercentage = performanceMetricDTO.TestPassPercentage;
            performanceMetric.Timestamp = performanceMetricDTO.Timestamp;

            return Ok();
        }

        #endregion Endpoints
    }
}