namespace Git.Services.RepositoriesService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Git.Common;
    using Git.Data;
    using Git.Repositories;
    using Git.Services.ModelsValidatorService;
    using Git.ViewModels;

    public class RepositoryService : IRepositoryService
    {
        private readonly IRepository repository;
        private readonly IModelValidatorService validator;

        public RepositoryService(ApplicationDbContext _context, IModelValidatorService _validator)
        {
            this.repository = new Repository(_context);
            validator = _validator;
        }

        public ICollection<RepositoryAllViewModel> AllRepositories(string userId)
        {
                return repository.All<Models.Repository>()
                .Where(r => r.OwnerId == userId || r.IsPublic == true)
                    .Select(r => new RepositoryAllViewModel()
                    {
                        Id = r.Id,
                        Name = r.Name,
                        CreatedOn = r.CreatedOn,
                        Owner = r.Owner.Username,
                        CommitsCount = r.Commits.Count(),
                    })
                    .ToList();
        }

        public ICollection<string> CreateRepository(CreateRepositoryViewModel repo, string ownerId)
        {
            var errors = validator.ValidateModel(repo);

            var isPublic = false;

            if (repo.RepositoryType == "Public")
            {
                isPublic = true;
            }

            if (errors.Count > 0)
            {
                return errors;
            }

            try
            {
                this.repository
                     .Add(new Models.Repository()
                     {
                         Name = repo.Name,
                         CreatedOn = DateTime.UtcNow,
                         IsPublic = isPublic,
                         OwnerId = ownerId,
                     });

                repository.SaveChanges();
            }
            catch (Exception)
            {
                errors.Add(Constants.MAJOR_ERROR);
            }

            return errors;
        }

    }
}
