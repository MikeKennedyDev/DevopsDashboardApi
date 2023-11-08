using DevopsDashboardApi.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevopsDashboardApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeploymentsController : ControllerBase
    {
        #region Fields

        private List<DeploymentDTO> _deployments = new List<DeploymentDTO>
        {
            new DeploymentDTO{ Id=1, ProjectName="Project 1", Version="1.0.0", Environment="Dev", Status="Success", DeployedAt=DateTime.Now },
            new DeploymentDTO{ Id=2, ProjectName="Project 2", Version="1.0.0", Environment="QA", Status="Failure", DeployedAt=DateTime.Now },
            new DeploymentDTO{ Id=3, ProjectName="Project 3", Version="1.0.0", Environment="Prod", Status="Success", DeployedAt=DateTime.Now },
        };

        #endregion Fields

        #region Endpoints

        [HttpPost]
        public IActionResult CreateDeployment([FromBody] DeploymentDTO deployment)
        {
            if (deployment == null)
            {
                return BadRequest();
            }
            _deployments.Add(deployment);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDeployment(int id)
        {
            var deployment = _deployments.Find(o => o.Id == id);
            if (deployment == null)
            {
                return NotFound();
            }
            _deployments.Remove(deployment);

            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetDeploymentById(int id)
        {
            var deployment = _deployments.Find(o => o.Id == id);
            if (deployment == null)
            {
                return NotFound();
            }
            return Ok(deployment);
        }

        [HttpGet]
        public IActionResult GetDeployments()
        {
            return Ok(_deployments);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDeployment(int id, [FromBody] DeploymentDTO deploymentDTO)
        {
            if (deploymentDTO == null || deploymentDTO.Id != id)
            {
                return BadRequest();
            }

            var deployment = _deployments.Find(o => o.Id == id);
            if (deployment == null)
            {
                return NotFound();
            }

            deployment.ProjectName = deploymentDTO.ProjectName;
            deployment.Version = deploymentDTO.Version;
            deployment.Environment = deploymentDTO.Environment;
            deployment.Status = deploymentDTO.Status;
            deployment.DeployedAt = deploymentDTO.DeployedAt;

            return Ok();
        }

        #endregion Endpoints
    }
}