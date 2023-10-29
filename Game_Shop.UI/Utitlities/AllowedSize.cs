using System.ComponentModel.DataAnnotations;

namespace Game_Shop.UI.Utitlities
{
    public class AllowedSize : ValidationAttribute
    {
        private readonly int maxAllowedSize;

        public AllowedSize(int maxAllowedSize)
        {
            this.maxAllowedSize = maxAllowedSize;
        }

        public override bool IsValid(object? value)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                if (file.Length > maxAllowedSize)
                    return false;
            }

            return true;
        }
    }
}
