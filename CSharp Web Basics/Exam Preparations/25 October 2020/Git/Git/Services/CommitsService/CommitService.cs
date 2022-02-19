namespace Git.Services.CommitsService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Git.Common;
    using Git.Data;
    using Git.Models;
    using Git.Repositories;
    using Git.Services.ModelsValidatorService;
    using Git.ViewModels;

    public class CommitService : ICommitService
    {
        private readonly IRepository repository;
        private readonly IModelValidatorService validator;
        private readonly ApplicationDbContext context;

        public CommitService(ApplicationDbContext _context, IModelValidatorService _validator)
        {
            this.repository = new Repositories.Repository(_context);
            validator = _validator;
            context = _context;
        }

        public Models.Repository GetRepository(string repoId)
        {
            return repository.All<Models.Repository>()
                .FirstOrDefault(r => r.Id == repoId);
        }

        public ICollection<string> CreateCommit(AddCommitViewModel commit, string userId)
        {
            var errors = validator.ValidateModel(commit);

            if (errors.Count > 0)
            {
                return errors;
            }

            try
            {
                this.repository
                     .Add(new Models.Commit()
                     {
                         Description = commit.Description,
                         CreatedOn = DateTime.UtcNow,
                         CreatorId = userId,
                         RepositoryId = commit.RepositoryId,
                     });

                repository.SaveChanges();
            }
            catch (Exception)
            {
                errors.Add(Constants.MAJOR_ERROR);
            }

            return errors;
        }

        public (ICollection<string>, ICollection<CommitViewModel>) AllCommits(string userId)
        {
            var errors = new List<string>();

            try
            {
                return (errors, this.repository
                     .All<Commit>()
                     .Where(c => c.CreatorId == userId)
                     .Select(c => new CommitViewModel 
                     { 
                         Id = c.Id,
                         Description = c.Description,
                         CreatedOn = c.CreatedOn.ToString(),
                         RepositoryName = c.Repository.Name,
                     })

                     .ToList());
            }
            catch (Exception)
            {
                errors.Add(Constants.MAJOR_ERROR);
            }

            return (errors, null);
        }

        public ICollection<string> DeleteCommit(string Id)
        {
            var errors = new List<string>();

            try
            {
                var commit = repository.All<Commit>()
                    .First(c => c.Id == Id);

                var commits = repository.All<Commit>()
                    .ToList();

                context.Commits.Remove(commit);


                context.SaveChanges();
            }
            catch (Exception)
            {
                errors.Add(Constants.MAJOR_ERROR);
            }

            return errors;
        }
    }
}
