using Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Validators
{
    public abstract class CommandQueryValidator<T> : AbstractValidator<T>
    {
        protected IApplicationDbContext Context { get; private set; }

        protected CommandQueryValidator(IApplicationDbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        protected async Task<bool> JobExists(int id, CancellationToken cancellationToken)
        {
            return await Context.Jobs.AnyAsync(j => j.Id == id, cancellationToken);
        }
    }
}
