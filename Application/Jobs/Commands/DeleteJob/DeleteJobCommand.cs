using Application.Common.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Jobs.Commands.DeleteJob
{
    public class DeleteJobCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteJobCommandHandler : IRequestHandler<DeleteJobCommand>
    {
        private readonly IApplicationDbContext context;

        public DeleteJobCommandHandler(IApplicationDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Unit> Handle(DeleteJobCommand request, CancellationToken cancellationToken)
        {
            var job = await context.Jobs.FindAsync(request.Id);

            context.Jobs.Remove(job);
            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
