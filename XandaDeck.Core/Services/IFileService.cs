using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace XandaDeck.Core.Services
{
    public interface IFileService
    {
        bool SaveFile(List<IFormFile> files, string subDirectory);
        (string fileType, byte[] archiveData, string archiveName) FetechFiles(string subDirectory);
        string SizeConverter(long bytes);
    }
}
