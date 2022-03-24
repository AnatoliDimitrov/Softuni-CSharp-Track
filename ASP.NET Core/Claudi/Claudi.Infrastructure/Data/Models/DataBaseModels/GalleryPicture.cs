namespace Claudi.Infrastructure.Data.Models.DataBaseModels
{
    using System.ComponentModel.DataAnnotations;

    public class GalleryPicture : BaseDeletableModel<string>
    {
        public GalleryPicture()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string? Group { get; init; }

        public string CssClass { get; set; }

        [Required]
        public string ImageUrl { get; init; }
    }
}
