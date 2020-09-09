using Application.Common.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Jobs.Commands.UpdateJob
{
    public class UpdateJobCommand : IRequest
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? ExpiresAt { get; set; }
    }

    public class UpdateJobCommandHandler : IRequestHandler<UpdateJobCommand>
    {
        private readonly IApplicationDbContext context;

        public UpdateJobCommandHandler(IApplicationDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Unit> Handle(UpdateJobCommand request, CancellationToken cancellationToken)
        {
            var job = await context.Jobs.FindAsync(request.Id);

            job.Title = request.Title ?? job.Title;
            job.Description = request.Description ?? job.Description;
            job.ExpiresAt = request.ExpiresAt ?? job.ExpiresAt;

            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
