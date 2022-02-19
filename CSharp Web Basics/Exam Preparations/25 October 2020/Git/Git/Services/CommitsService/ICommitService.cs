namespace Git.Services.CommitsService
{
    using System.Collections.Generic;

    using Git.ViewModels;

    public interface ICommitService
    {
        Models.Repository GetRepository(string repoId);

        ICollection<string> CreateCommit(AddCommitViewModel commit, string userId);

        (ICollection<string>, ICollection<CommitViewModel>) AllCommits(string userId);

        ICollection<string> DeleteCommit(string Id);
    }
}
