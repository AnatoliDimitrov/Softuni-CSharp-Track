namespace Claudi.Web.Models.DataBaseModels
{
    public class ConfiguredProductExtra
    {
        public string ConfiguredProductId { get; init; }
        public virtual ConfiguredProduct ConfiguredProduct { get; set; }

        public int ExtraId { get; set; }
        public virtual ProductExtra Extra { get; set; }
    }
}
