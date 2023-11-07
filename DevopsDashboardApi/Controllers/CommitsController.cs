using DevopsDashboardApi.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevopsDashboardApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommitsController : ControllerBase
    {
        #region Fields

        private List<CommitDTO> _commits = new List<CommitDTO>
        {
            new CommitDTO{ Id=1, Author="Mike", Hash="123", Message="Commit 1", Timestamp=DateTime.Now },
            new CommitDTO{ Id=2, Author="Kennedy", Hash="456", Message="Commit 2", Timestamp=DateTime.Now },
            new CommitDTO{ Id=3, Author="Dev", Hash="789", Message="Commit 3", Timestamp=DateTime.Now },
        };

        #endregion Fields

        #region Endpoints

        [HttpPost]
        public IActionResult CreateCommit([FromBody] CommitDTO commit)
        {
            if (commit == null)
            {
                return BadRequest();
            }
            _commits.Add(commit);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCommit(int id)
        {
            if (_commits.Find(o => o.Id == id) == null)
            {
                return NotFound();
            }
            _commits.Remove(_commits.Find(o => o.Id == id));

            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetCommitById(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult GetRecentCommits()
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCommit(int id)
        {
            throw new NotImplementedException();
        }

        #endregion Endpoints
    }
}