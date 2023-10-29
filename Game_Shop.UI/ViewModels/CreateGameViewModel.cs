using Game_Shop.UI.Utitlities;
using System.ComponentModel.DataAnnotations;

namespace Game_Shop.UI.ViewModels
{
    public class CreateGameViewModel: GameViewModel
    {
        [AllowedExtension(".jpg", ".png", ErrorMessage = "Not Allowed Image extenstion")]

        [AllowedSize((Settings.MaximimFileSizeInBytes), ErrorMessage = "Maximum Allowed size is 1 Mb")]
        public IFormFile CoverImage { get; set; } = default!;
    }
}
