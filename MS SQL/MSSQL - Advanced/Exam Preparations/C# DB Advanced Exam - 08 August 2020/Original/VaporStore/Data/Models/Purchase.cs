using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VaporStore.Data.Models;
using VaporStore.Data.Models.Enums;

namespace VaporStore.Data
{
    public class Purchase
    {
        [Key]
        public int Id { get; set; }

        public virtual PurchaseType Type { get; set; }

        [Required]
        public string ProductKey { get; set; }

        public DateTime Date { get; set; }

        [ForeignKey(nameof(Card))]
        public int CardId { get; set; }
        public virtual Card Card { get; set; }

        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }
        public virtual Game Game { get; set; }
    }
}
