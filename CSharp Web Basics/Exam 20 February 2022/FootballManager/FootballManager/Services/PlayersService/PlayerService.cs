namespace FootballManager.Services.PlayersService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using FootballManager.Common;
    using FootballManager.Data;
    using FootballManager.Data.Models;
    using FootballManager.Repositories;
    using FootballManager.Services.ModelsValidatorService;
    using FootballManager.ViewModels.Players;

    public class PlayerService : IPlayerService
    {
        private readonly IRepository repository;
        private readonly IModelValidatorService validator;
        private readonly FootballManagerDbContext context;

        public PlayerService(FootballManagerDbContext _context, IModelValidatorService _validator)
        {
            this.repository = new Repository(_context);
            validator = _validator;
            context = _context;
        }

        public (ICollection<string>, ICollection<AllPlayerViewModel>) AllPlayers()
        {
            var errors = new List<string>();

            try
            {
                return (errors, this.repository
                     .All<Player>()
                     .Select(c => new AllPlayerViewModel
                     {
                         Id = c.Id,
                         FullName = c.FullName,
                         ImageUrl = c.ImageUrl,
                         Position = c.Position,
                         Speed = c.Speed,
                         Endurance = c.Endurance,
                         Description = c.Description,
                     })

                     .ToList());
            }
            catch (Exception)
            {
                errors.Add(Constants.MAJOR_ERROR);
            }

            return (errors, null);
        }

        public (ICollection<string>, ICollection<AllPlayerViewModel>) MyPlayers(string userId)
        {
            var errors = new List<string>();

            try
            {
                var players = this.repository
                    .All<UserPlayer>()
                    .Where(p => p.UserId == userId)
                    .Select(p => p.PlayerId)
                    .ToList();

                return (errors, this.repository
                     .All<Player>()
                     .Where(p => players.Contains(p.Id))
                     .Select(c => new AllPlayerViewModel
                     {
                         Id = c.Id,
                         FullName = c.FullName,
                         ImageUrl = c.ImageUrl,
                         Position = c.Position,
                         Speed = c.Speed,
                         Endurance = c.Endurance,
                         Description = c.Description,
                     })
                     .ToList());
            }
            catch (Exception)
            {
                errors.Add(Constants.MAJOR_ERROR);
            }

            return (errors, null);
        }

        public ICollection<string> AddPlayer(AddPlayerViewModel model, string userId)
        {
            var errors = validator.ValidateModel(model);

            if (errors.Count > 0)
            {
                return errors;
            }

            try
            {
                var player = new Player()
                {
                    FullName = model.FullName,
                    ImageUrl = model.ImageUrl,
                    Position = model.Position,
                    Speed = byte.Parse(model.Speed),
                    Endurance = byte.Parse(model.Endurance),
                    Description = model.Description,
                };

                this.repository
                     .Add(player);

                this.repository
                    .Add(new UserPlayer() { PlayerId = player.Id, UserId = userId });

                repository.SaveChanges();
            }
            catch (Exception)
            {
                errors.Add(Constants.MAJOR_ERROR);
            }

            return errors;
        }

        public ICollection<string> AddPlayerToCollection(string playerId, string userId)
        {
            var errors = new List<string>();

            var userPlayer = this.repository
                .All<UserPlayer>()
                .FirstOrDefault(x => x.PlayerId == playerId && x.UserId == userId);

            if (userPlayer != null)
            {
                errors.Add("Already Added.");
                return errors;
            }

            try
            {
                this.repository
                     .Add(new UserPlayer() { PlayerId = playerId, UserId = userId});

                repository.SaveChanges();
            }
            catch (Exception)
            {
                errors.Add(Constants.MAJOR_ERROR);
            }

            return errors;
        }

        public ICollection<string> DeletePlayerFromCollection(string playerId, string userId)
        {
            var errors = new List<string>();

            try
            {
                var player = this.repository
                    .All<Player>()
                    .First(p => p.Id == playerId);

                var userPlayer = this.repository
                     .All<UserPlayer>()
                     .First(x => x.PlayerId == playerId && x.UserId == userId);

                var user = this.repository
                     .All<User>()
                     .First(u => u.Id == userId);

                user.UserPlayers.Remove(userPlayer);

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
