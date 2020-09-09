using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Jobs.Commands.CreateJob
{
    public class CreateJobCommand : IRequest<int>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime ExpiresAt { get; set; }
    }

    public class CreateJobCommandHandler : IRequestHandler<CreateJobCommand, int>
    {
        private readonly IApplicationDbContext context;

        public CreateJobCommandHandler(IApplicationDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<int> Handle(CreateJobCommand request, CancellationToken cancellationToken)
        {
            var job = new Job(request.Title, request.Description, request.ExpiresAt);

            context.Jobs.Add(job);

            await context.SaveChangesAsync(cancellationToken);

            return job.Id;
        }
    }
}
