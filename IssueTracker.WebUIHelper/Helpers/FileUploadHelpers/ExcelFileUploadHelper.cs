using System.Web.UI.WebControls;
using IssueTracker.BusinessLayer.Base;
using IssueTracker.WebUIHelper.Abstracts;

namespace IssueTracker.WebUIHelper.Helpers.FileUploadHelpers
{
    public class ExcelFileUploadHelper : FileUploadHelper, IDocFileUploader
    {
        public Result<FileUploadResponse> Upload(FileUpload fileUpload, string destinationPath, string imageSuffix)
        {
            var fileNameResult = GenerateFileName(
                fileUpload,
                destinationPath,
                imageSuffix,
                ".XLS, and .XLSX",
                (e) => HasValidFile(e));

            if (fileNameResult.IsSuccess == false)
                return Result<FileUploadResponse>.Failure(fileNameResult.Error);

            string fileName = fileNameResult.Value.ToString();

            string filePath = FileUpload(fileUpload, destinationPath, fileName);

            return Result<FileUploadResponse>.Success(new FileUploadResponse(filePath, fileName), "Success! Excel file has been uploaded successfully.");
        }

        private bool HasValidFile(string extension)
        {
            return extension == DocumentFileType.XLS.ToString() ||
                extension == DocumentFileType.XLSX.ToString();
        }

        private enum DocumentFileType
        {
            XLS,
            XLSX
        }
    }
}
