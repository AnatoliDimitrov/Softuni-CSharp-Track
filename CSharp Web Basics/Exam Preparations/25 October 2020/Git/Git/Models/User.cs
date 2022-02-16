namespace Git.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Git.Common;

    public class User
    {
        public User()
        {
            this.Repositories = new HashSet<Repository>();
            this.Commits = new HashSet<Commit>();
        }

        [Key]
        [StringLength(Constants.LENGTH_100)]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(Constants.LENGTH_20)]
        public string Username { get; init; }

        [Required]
        [StringLength(Constants.LENGTH_100)]
        public string Email { get; init; }

        [Required]
        [StringLength(Constants.LENGTH_100)]
        public string Password { get; init; }

        public ICollection<Repository> Repositories { get; set; }

        public ICollection<Commit> Commits { get; set; }
    }
}
