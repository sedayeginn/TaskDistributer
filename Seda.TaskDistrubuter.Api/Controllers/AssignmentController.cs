using Microsoft.AspNetCore.Mvc;
using Seda.TaskDistrubuter.Api.DTOS;

namespace Seda.TaskDistrubuter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<AssignmentDto> GetAssignments()
        {
            return 
        }
    }
}
