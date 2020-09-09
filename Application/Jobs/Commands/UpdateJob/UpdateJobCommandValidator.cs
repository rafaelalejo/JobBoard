using Application.Common.Interfaces;
using Application.Common.Validators;
using FluentValidation;
using System;

namespace Application.Jobs.Commands.UpdateJob
{
    public class UpdateJobCommandValidator : CommandQueryValidator<UpdateJobCommand>
    {
        public UpdateJobCommandValidator(IApplicationDbContext context) : base(context)
        {
            RuleFor(c => c.Id)
                .MustAsync(JobExists)
                .WithMessage("Invalid job id.");

            RuleFor(c => c.Title)
                .NotEmpty().When(c => c.Title != null);
            RuleFor(c => c.Description)
                .NotEmpty().When(c => c.Description != null);
            RuleFor(c => c.ExpiresAt)
                .GreaterThan(DateTime.Now).When(c => c.ExpiresAt.HasValue)
                .WithMessage("Expiration date should be in the future.");
        }
    }
}
