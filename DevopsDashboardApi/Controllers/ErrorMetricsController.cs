using DevopsDashboardApi.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevopsDashboardApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorMetricsController : ControllerBase
    {
        #region Fields

        private List<ErrorMetricDTO> _errorMetrics = new List<ErrorMetricDTO>
        {
            new ErrorMetricDTO{ Id=1, IsResolved=true, ErrorMessage="Error 1", ProjectName="Test proj 1", Severity="Low",Timestamp=DateTime.Now },
            new ErrorMetricDTO{ Id=2, IsResolved=false, ErrorMessage="Error 2", ProjectName="Test proj 2", Severity="Medium",Timestamp=DateTime.Now },
            new ErrorMetricDTO{ Id=3, IsResolved=true, ErrorMessage="Error 3", ProjectName="Test proj 3", Severity="High",Timestamp=DateTime.Now },
        };

        #endregion Fields

        #region Endpoints

        [HttpPost]
        public IActionResult CreateErrorMetric([FromBody] ErrorMetricDTO errorMetric)
        {
            if (errorMetric == null)
            {
                return BadRequest();
            }
            _errorMetrics.Add(errorMetric);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteErrorMetric(int id)
        {
            var errorMetric = _errorMetrics.Find(o => o.Id == id);
            if (errorMetric == null)
            {
                return NotFound();
            }
            _errorMetrics.Remove(errorMetric);

            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetErrorMetricById(int id)
        {
            var errorMetric = _errorMetrics.Find(o => o.Id == id);
            if (errorMetric == null)
            {
                return NotFound();
            }
            return Ok(errorMetric);
        }

        [HttpGet]
        public IActionResult GetErrorMetrics()
        {
            return Ok(_errorMetrics);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateErrorMetric(int id, [FromBody] ErrorMetricDTO errorMetricDTO)
        {
            if (errorMetricDTO == null || errorMetricDTO.Id != id)
            {
                return BadRequest();
            }

            var errorMetric = _errorMetrics.Find(o => o.Id == id);
            if (errorMetric == null)
            {
                return NotFound();
            }

            errorMetric.ErrorMessage = errorMetricDTO.ErrorMessage;
            errorMetric.IsResolved = errorMetricDTO.IsResolved;
            errorMetric.ProjectName = errorMetricDTO.ProjectName;
            errorMetric.Severity = errorMetricDTO.Severity;
            errorMetric.Timestamp = errorMetricDTO.Timestamp;

            return Ok();
        }

        #endregion Endpoints
    }
}