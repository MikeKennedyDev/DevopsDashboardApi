using DevopsDashboardApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevopsDashboardApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildsController : ControllerBase
    {
        #region Fields

        private static readonly List<Build> mockBuilds = new List<Build>
        {
            new Build { Id = 1, ProjectName = "DevopsDashboardApi", Branch = "master", Status = "Succeeded", Duration = "00:00:10", StartTime = DateTime.Now },
            new Build { Id = 2, ProjectName = "DevopsDashboardApi", Branch = "master", Status = "Failed", Duration = "00:00:15", StartTime = DateTime.Now },
            new Build { Id = 3, ProjectName = "DevopsDashboardApi", Branch = "master", Status = "Succeeded", Duration = "00:00:05", StartTime = DateTime.Now },
        };

        #endregion Fields

        #region Endpoints

        [HttpDelete("{id}")]
        public IActionResult DeleteBuild(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult GetBuildById(int id)
        {
            var build = mockBuilds.Find(o => o.Id == id);
            if (build == null)
            {
                return NotFound();
            }
            return Ok(build);
        }

        [HttpGet("{id}")]
        public IActionResult GetRecentBuilds()
        {
            return Ok(mockBuilds);
        }

        [HttpPost]
        public IActionResult TriggerBuild()
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBuild(int id)
        {
            throw new NotImplementedException();
        }

        #endregion Endpoints
    }
}