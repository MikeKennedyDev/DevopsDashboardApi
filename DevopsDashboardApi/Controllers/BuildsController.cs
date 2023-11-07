using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevopsDashboardApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildsController : ControllerBase
    {
        #region Endpoints

        [HttpDelete("{id}")]
        public IActionResult DeleteBuild(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult GetBuildById(int id)
        {
            return Ok();
            //throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public IActionResult GetRecentBuilds()
        {
            throw new NotImplementedException();
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