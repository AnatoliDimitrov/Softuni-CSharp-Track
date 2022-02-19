namespace Git.Services.RepositoriesService
{
    using System.Collections.Generic;

    using Git.ViewModels;

    public interface IRepositoryService
    {
        ICollection<RepositoryAllViewModel> AllRepositories(string userId);

        ICollection<string> CreateRepository(CreateRepositoryViewModel repo, string ownerId);
    }
}
