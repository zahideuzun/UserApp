using Microsoft.AspNetCore.Http;

namespace UserApp.AppCore
{
    public class FileStringBase
    {
        //todo bu metoda nasil unit test yazarim? 
        public  string SaveFileToTempLocation(IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName);
            var newImageName = Guid.NewGuid() + extension;
            var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/", newImageName);
            using (var stream = new FileStream(location, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return newImageName;
        }
    }

    
}
