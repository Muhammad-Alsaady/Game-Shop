using Game_Shop.UI.Utitlities;
using System.ComponentModel.DataAnnotations;

namespace Game_Shop.UI.ViewModels
{
    public class EditGameViewModel: GameViewModel
    {
        [AllowedExtension(".jpg", ".png", ErrorMessage = "Not Allowed Image extenstion")]

        [AllowedSize((Settings.MaximimFileSizeInBytes), ErrorMessage = "Maximum Allowed size is 1 Mb")]
        public IFormFile? CoverImage { get; set; } = default!;
        [MaxLength(100)]
        public string? CurrentCoverImage { get; set; } 
    }
}
