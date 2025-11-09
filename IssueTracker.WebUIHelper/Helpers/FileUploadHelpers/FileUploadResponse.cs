using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.WebUIHelper.Helpers.FileUploadHelpers
{
    public class FileUploadResponse
    {
        public string FilePath { get; private set; }
        public string FileName { get; private set; }
        public FileUploadResponse(string filePath, string fileName)
        {
            FilePath = filePath;
            FileName = fileName;
        }
    }
}
