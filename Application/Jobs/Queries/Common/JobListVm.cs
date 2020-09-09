using System;
using System.Collections.Generic;

namespace Application.Jobs.Queries.Common
{
    public class JobListVm
    {
        public JobListVm(IList<JobVm> jobs)
        {
            Jobs = jobs ?? throw new ArgumentNullException(nameof(jobs));
        }

        public int Count => Jobs.Count;

        public IList<JobVm> Jobs { get; private set; }
    }
}
