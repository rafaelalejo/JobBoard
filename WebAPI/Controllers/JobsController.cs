﻿using Application.Jobs.Queries.Common;
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
    }
}