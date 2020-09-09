using FluentValidation;
using System;

namespace Application.Jobs.Commands.CreateJob
{
    public class CreateJobCommandValidator : AbstractValidator<CreateJobCommand>
    {
        public CreateJobCommandValidator()
        {
            RuleFor(c => c.Title).NotEmpty();
            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.ExpiresAt).GreaterThan(DateTime.Now);
        }
    }
}
