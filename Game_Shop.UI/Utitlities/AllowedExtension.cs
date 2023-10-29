using NuGet.Packaging.Signing;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;

namespace Game_Shop.UI.Utitlities
{
    public class AllowedExtension: ValidationAttribute
    {
        private readonly string[] allowedExtensions;

        public AllowedExtension(params string[] allowedExtensions)
        {
            this.allowedExtensions = allowedExtensions;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                /// 1. Get the File Extension
                var uploadedFileExtension = Path.GetExtension(file.FileName);

                /// 2. Compare between File Extension and the allowedExtensions
                var isValid = allowedExtensions.Any(allowedExtensions =>
                    string.Equals(uploadedFileExtension, allowedExtensions, StringComparison.OrdinalIgnoreCase));

                /// 3. Return Seuccess if isValid

                if (!isValid)
                    return new ValidationResult($"Only {string.Join(',', allowedExtensions)} are Allowed");
            }
            return ValidationResult.Success;
        }
    }


}

