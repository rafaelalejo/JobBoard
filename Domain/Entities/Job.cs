using System;

namespace Domain.Entities
{
    public class Job
    {
        public Job(string title, string description, DateTime expiresAt)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            CreatedAt = DateTime.Now;
            ExpiresAt = expiresAt;
        }

        public int Id { get; private set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ExpiresAt { get; set; }
    }
}
