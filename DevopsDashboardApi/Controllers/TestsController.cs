using DevopsDashboardApi.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevopsDashboardApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        #region Fields

        private List<TestResultDTO> _tests = new List<TestResultDTO>
        {
            new TestResultDTO{ Id=1, ProjectName="Project 1", TestName="Test 1", Passed=true, Timestamp=DateTime.Now },
            new TestResultDTO{ Id=2, ProjectName="Project 2", TestName="Test 2", Passed=false, Timestamp=DateTime.Now },
            new TestResultDTO{ Id=3, ProjectName="Project 3", TestName="Test 3", Passed=true, Timestamp=DateTime.Now },
        };

        #endregion Fields

        #region Endpionts

        [HttpPost]
        public IActionResult CreateTest([FromBody] TestResultDTO test)
        {
            if (test == null)
            {
                return BadRequest();
            }
            _tests.Add(test);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTest(int id)
        {
            var test = _tests.Find(o => o.Id == id);
            if (test == null)
            {
                return NotFound();
            }
            _tests.Remove(test);

            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetTestById(int id)
        {
            var test = _tests.Find(o => o.Id == id);
            if (test == null)
            {
                return NotFound();
            }
            return Ok(test);
        }

        [HttpGet]
        public IActionResult GetTests()
        {
            return Ok(_tests);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTest(int id, [FromBody] TestResultDTO test)
        {
            if (test == null || test.Id != id)
            {
                return BadRequest();
            }

            var testToUpdate = _tests.Find(o => o.Id == id);
            if (testToUpdate == null)
            {
                return NotFound();
            }

            testToUpdate.Passed = test.Passed;
            testToUpdate.ProjectName = test.ProjectName;
            testToUpdate.TestName = test.TestName;
            testToUpdate.Timestamp = test.Timestamp;

            return Ok();
        }

        #endregion Endpionts
    }
}