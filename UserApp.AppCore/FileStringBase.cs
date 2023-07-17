using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApp.AppCore.Core.Bases;

namespace UserApp.AppCore
{
    public static class FileStringBase
    {
        public static string SaveFileToTempLocation(IFormFile file)
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

        public static string MoveFileToDestination(string sourceFilePath)
        {
            // Dosyanın taşınacağı veya işleneceği hedef konumu belirleyin
            string destinationPath = "Hedef/Konumu/Dizin/DosyaAdi.jpg";

            // Geçici konumdan hedef konuma dosyayı taşıyın
            File.Move(sourceFilePath, destinationPath);

            // Hedef konumunu veya dosya yolunu dönün
            return destinationPath;
        }
    }

    
}
