using Git.ViewModels;
using System.Collections.Generic;

namespace Git.Services.RepositoriesService
{
    public interface IRepositoryService
    {
        ICollection<RepositoryAllViewModel> AllRepositories(string userId);

        ICollection<string> CreateRepository(CreateRepositoryViewModel repo, string ownerId);
    }
}
