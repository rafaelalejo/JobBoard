using Application.Jobs.Commands.CreateJob;
using Application.Jobs.Commands.DeleteJob;
using Application.Jobs.Commands.UpdateJob;
using Application.Jobs.Queries.Common;
using Application.Jobs.Queries.GetAllJobs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class JobsController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<JobListVm>> GetAllJobs()
        {
            return Ok(await Mediator.Send(new GetAllJobsQuery()));
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateJobCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPatch]
        public async Task<ActionResult> Update(UpdateJobCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteJobCommand { Id = id, });

            return NoContent();
        }
    }
}
