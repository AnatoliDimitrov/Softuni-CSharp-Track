namespace Claudi.Web.Models.DataBaseModels
{
    using System.ComponentModel.DataAnnotations;

    public class ConfiguredProductUser : BaseDeletableModel<string>
    {
        public ConfiguredProductUser()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string ConfiguredProductId { get; init; }
        public virtual ConfiguredProduct ConfiguredProduct { get; set; }

        [Required]
        public string UserId { get; set; }

        public bool Ordered { get; set; }

        public DateTime? OrderedOn { get; set; }

        public bool Completed { get; set; }

        public DateTime? CompletedOn { get; set; }

        public int Quantity { get; set; }
    }
}
