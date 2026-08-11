using Microsoft.AspNetCore.Http;

namespace src.application.Beats.Handlers
{
    public class FileValidator
    {
        public static bool validateFileExtension(IFormFile file, string[] fileExtension)
        {
            var extension = Path.GetExtension(file.FileName);

            if (!fileExtension.Contains(extension))
            {
                return false;
            }
            return true;

        }
    }
}