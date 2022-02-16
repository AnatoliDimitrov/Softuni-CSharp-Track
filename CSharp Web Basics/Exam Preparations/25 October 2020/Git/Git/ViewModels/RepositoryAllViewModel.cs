using Git.Models;
using System;
using System.Collections.Generic;

namespace Git.ViewModels
{
    public class RepositoryAllViewModel
    {
        public string Id { get; init; }

        public string Name { get; init; }

        public DateTime CreatedOn { get; init; }

        public string Owner { get; init; }

        public int CommitsCount { get; init; }
    }
}
