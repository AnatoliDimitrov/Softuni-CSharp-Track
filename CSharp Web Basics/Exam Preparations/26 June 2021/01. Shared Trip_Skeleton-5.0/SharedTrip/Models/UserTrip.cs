namespace SharedTrip.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserTrip
    {
        [ForeignKey(nameof(User))]
        public string UserId { get; init; }
        public User User { get; set; }

        [ForeignKey(nameof(Trip))]
        public string TripId { get; init; }
        public Trip Trip { get; set; }
    }
}

apdimitrov@yahoooooooooooooooooooooooooooooooooooooooooo.com