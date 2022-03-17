using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace XandaDeck.Core.Services
{
    public static class FileUploadService
    {
        public static byte[] ToZip(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);

            // full path to file in temp location: var filePath = Path.GetTempFileName();
            var tempPath = Path.GetTempPath();
            var filePath = tempPath + "/submission/";
            var archiveFile = tempPath + "/zip/archive.zip";
            var archivePath = tempPath + "/zip/";
            if (Directory.Exists(filePath))
            {
                Directory.Delete(filePath, true);
            }
            if (Directory.Exists(archivePath))
            {
                Directory.Delete(archivePath, true);
            }

            Directory.CreateDirectory(filePath);
            Directory.CreateDirectory(archivePath);

            foreach (var formFile in files)
            {
                var fileName = filePath + formFile.FileName;
                if (formFile.Length > 0)
                {
                    using (var stream = new FileStream(fileName, FileMode.Create))
                    {
                        formFile.CopyToAsync(stream);
                    }
                }
            }
            ZipFile.CreateFromDirectory(filePath, archiveFile);
            /* beapen: 2017/07/24
             * 
             * Currently A Filestream cannot be directly converted to a byte array.
             * Hence it is copied to a memory stream before serializing it.
             * This may change in the future and may require refactoring.
             * 
             */
            var stream2 = new FileStream(archiveFile, FileMode.Open);
            var memoryStream = new MemoryStream();
            stream2.CopyTo(memoryStream);
            using (memoryStream)
            {
                return memoryStream.ToArray();
            }
        }

        public static string CheckInvalidChars(string fileNme)
        {
            char[] invalidFileChars = Path.GetInvalidFileNameChars();

            foreach (char someChar in invalidFileChars)
            {
                if (fileNme.Contains(someChar))
                {
                    fileNme = fileNme.Replace(someChar, Convert.ToChar(""));
                }
            }

            fileNme = fileNme.Replace(Convert.ToChar(" "), Convert.ToChar("_"));

            return fileNme;
        }

        public static string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private static Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformatsofficedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }

        public static void FileResize(IFormFile file, string filePath, int width, int height)
        {

            var fileName = Path.GetFileName(file.FileName);

            var path = Path.Combine(filePath, fileName);

            fileName = $"thumb_{fileName}";

            var thumbPath = Path.Combine(filePath, fileName);

            // Image.Load(string path) is a shortcut for our default type. 
            // Other pixel formats use Image.Load<TPixel>(string path))
            using (Image image = Image.Load(path))
            {
                image.Mutate(x => x
                     .Resize(width, height)
                );
                image.Save(thumbPath); // Automatic encoder selected based on extension.
            }

            return;
        }
    }
}
