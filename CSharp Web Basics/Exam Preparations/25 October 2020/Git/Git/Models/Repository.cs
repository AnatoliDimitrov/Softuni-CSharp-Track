namespace Git.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Git.Common;

    public class Repository
    {
        public Repository()
        {
            this.Commits = new HashSet<Commit>();
        }

        [Key]
        [StringLength(Constants.LENGTH_100)]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(Constants.LENGTH_10)]
        public string Name { get; init; }

        [Required]
        public DateTime CreatedOn { get; init; }

        [Required]
        public bool IsPublic { get; init; }

        [ForeignKey(nameof(Owner))]
        public string OwnerId { get; init; }
        public User Owner { get; set; }

        public ICollection<Commit> Commits { get; set; }
    }
}
