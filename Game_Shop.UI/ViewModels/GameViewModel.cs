using Game_Shop.UI.Utitlities;
using System.ComponentModel.DataAnnotations;

namespace Game_Shop.UI.ViewModels
{
    public class GameViewModel
    {
        public int GameId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(2500)]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Category")]
        public byte CategoryId { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; } = Enumerable.Empty<SelectListItem>();

        [Display(Name = "Devices")]
        public List<int> SelectedDevices { get; set; } = default!;
        public IEnumerable<SelectListItem> DeviceList { get; set; } = Enumerable.Empty<SelectListItem>();
    }
}
