namespace Claudi.Core.ViewModels.ColorsViewModels
{
    public class ColorsViewModel
    {
        public string Type { get; set; }

        public IEnumerable<ColorsGroupsViewModel> Groups { get; set; }

        public IEnumerable<ColorViewModel> Colors { get; set; }
    }
}
