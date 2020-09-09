using Application.Common.Interfaces;
using Application.Jobs.Queries.Common;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Jobs.Queries.GetAllJobs
{
    public class GetAllJobsQuery : IRequest<JobListVm>
    {
    }

    public class GetAllJobsHandler : IRequestHandler<GetAllJobsQuery, JobListVm>
    {
        private readonly IApplicationDbContext context;
        private readonly IMapper mapper;

        public GetAllJobsHandler(IApplicationDbContext context, IMapper mapper)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<JobListVm> Handle(GetAllJobsQuery request, CancellationToken cancellationToken)
        {
            var jobs = await context.Jobs
                .ProjectTo<JobVm>(mapper.ConfigurationProvider)
                .ToListAsync();

            return new JobListVm(jobs);
        }
    }
}
