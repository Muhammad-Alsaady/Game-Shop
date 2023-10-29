
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace Game_Shop.Database.Models
{
    public class Game
    {
        public int GameId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(2500)]
        public string Description { get; set; } = string.Empty;
        [MaxLength(50)]
        public string CoverImage { get; set; } = string.Empty;
        public byte CategoryId  { get; set; }

        ///Nav. Properties
        public virtual Category Category { get; set; }
        public virtual ICollection<GameDevice> GameDevices { get; set; } = new HashSet<GameDevice>();
    }
}
