using Application.Common.Interfaces;
using Application.Common.Validators;
using FluentValidation;

namespace Application.Jobs.Commands.DeleteJob
{
    public class DeleteJobCommandValidator : CommandQueryValidator<DeleteJobCommand>
    {
        public DeleteJobCommandValidator(IApplicationDbContext context) : base(context)
        {
            RuleFor(c => c.Id)
                .MustAsync(JobExists)
                .WithMessage("Invalid job id.");
        }
    }
}
