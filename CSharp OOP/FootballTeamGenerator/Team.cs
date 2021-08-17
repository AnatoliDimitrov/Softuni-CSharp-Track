using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
		private List<Player> players;

		public Team(string name)
		{
			this.Name = name;
			this.players = new List<Player>();
		}

		public string Name
		{
			get { return name; }
			private set { name = GeneratorValidator.ValidateName(value); }
		}

		public int Rating
		=> GetRating();


		public void AddPlayer(Player player)
		{
			this.players.Add(player);
		}

		public int GetRating()
		{
			if (players.Count == 0)
			{
				return 0;
			}
			return (int)Math.Round(this.players.Sum(p => p.OverallSkillLevel) / (double)this.players.Count);
		}

		public void RemovePlayer(string name)
		{
			Player player = this.players
				.FirstOrDefault(p => p.Name == name);

			if (player == null)
			{
				throw new ArgumentException(String.Format(GlobalExceptionMessages.invalidPlayerToRemove, name, this.Name));
			}

			players.Remove(player);
		}
	}
}
