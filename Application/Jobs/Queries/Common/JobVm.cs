using Application.Common.Mappings;
using Domain.Entities;
using System;

namespace Application.Jobs.Queries.Common
{
    public class JobVm : IMapFrom<Job>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ExpiresAt { get; set; }
    }
}
