namespace FootballManager.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserPlayer
    {
        [ForeignKey(nameof(User))]
        public string UserId { get; init; }
        public User User { get; set; }

        [ForeignKey(nameof(Player))]
        public string PlayerId { get; init; }
        public Player Player { get; set; }
    }
}
