using System.Web.UI.WebControls;
using IssueTracker.ModelLayer.Base;
using IssueTracker.WebUIHelper.Abstracts;

namespace IssueTracker.WebUIHelper.Helpers.FileUploadHelpers
{
    public class DocumentFileUploadHelper : FileUploadHelper, IDocFileUploader
    {
        public Result<FileUploadResponse> Upload(FileUpload fileUpload, string destinationPath, string imageSuffix)
        {
            var fileNameResult = GenerateFileName(
                fileUpload,
                destinationPath,
                imageSuffix,
                ".DOC, .DOCX, .XLS, .XLSX and .PDF",
                (e) => HasValidFile(e));

            if (fileNameResult.IsSuccess == false)
                return Result<FileUploadResponse>.Failure(fileNameResult.Error);

            string fileName = fileNameResult.Value.ToString();

            string filePath = FileUpload(fileUpload, destinationPath, fileName);

            return Result<FileUploadResponse>.Success(value: new FileUploadResponse(filePath, fileName), message: "Success! Document file has been uploaded successfully.");
        }

        private bool HasValidFile(string extension)
        {
            return extension == DocumentFileType.DOC.ToString() ||
                extension == DocumentFileType.DOCX.ToString() ||
                extension == DocumentFileType.XLS.ToString() ||
                extension == DocumentFileType.XLSX.ToString() ||
                extension == DocumentFileType.PDF.ToString();
        }

        private enum DocumentFileType
        {
            DOC,
            DOCX,
            XLS,
            XLSX,
            PDF
        }
    }
}
