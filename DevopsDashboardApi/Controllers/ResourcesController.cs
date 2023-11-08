using DevopsDashboardApi.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevopsDashboardApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourcesController : ControllerBase
    {
        #region Fields

        private List<ResourceUtilizationDTO> _resources = new List<ResourceUtilizationDTO>
        {
            new ResourceUtilizationDTO{ Id=1, CpuPercentage=20, MemoryPercentage=20, Timestamp=DateTime.Now },
            new ResourceUtilizationDTO{ Id=2, CpuPercentage = 30, MemoryPercentage = 30, Timestamp = DateTime.Now },
            new ResourceUtilizationDTO{ Id=3, CpuPercentage = 40, MemoryPercentage = 40, Timestamp = DateTime.Now },
        };

        #endregion Fields

        #region Endpoints

        [HttpPost]
        public IActionResult CreateResource([FromBody] ResourceUtilizationDTO resource)
        {
            if (resource == null)
            {
                return BadRequest();
            }
            _resources.Add(resource);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteResource(int id)
        {
            var resource = _resources.Find(o => o.Id == id);
            if (resource == null)
            {
                return NotFound();
            }
            _resources.Remove(resource);

            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetResourceById(int id)
        {
            var resource = _resources.Find(o => o.Id == id);
            if (resource == null)
            {
                return NotFound();
            }
            return Ok(resource);
        }

        [HttpGet]
        public IActionResult GetResources()
        {
            return Ok(_resources);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateResource(int id, [FromBody] ResourceUtilizationDTO resourceDTO)
        {
            if (resourceDTO == null || resourceDTO.Id != id)
            {
                return BadRequest();
            }

            var resource = _resources.Find(o => o.Id == id);
            if (resource == null)
            {
                return NotFound();
            }

            resource.CpuPercentage = resourceDTO.CpuPercentage;
            resource.MemoryPercentage = resourceDTO.MemoryPercentage;
            resource.Timestamp = resourceDTO.Timestamp;

            return Ok();
        }

        #endregion Endpoints
    }
}