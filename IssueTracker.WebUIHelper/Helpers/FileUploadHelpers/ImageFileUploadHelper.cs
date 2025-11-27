using System.Web.UI.WebControls;
using IssueTracker.BusinessLayer.Base;
using IssueTracker.WebUIHelper.Abstracts;

namespace IssueTracker.WebUIHelper.Helpers.FileUploadHelpers
{
    public class ImageFileUploadHelper : FileUploadHelper, IImageFileUploader
    {
        public Result<FileUploadResponse> Upload(FileUpload fileUpload, string destinationPath, string imageSuffix)
        {
            var fileNameResult = GenerateFileName(
                fileUpload,
                destinationPath,
                imageSuffix,
                ".JPG, .JPEG, .PNG, .BMP and .GIF",
                (e) => HasValidFile(e));

            if (fileNameResult.IsSuccess == false)
                return Result<FileUploadResponse>.Failure(fileNameResult.Error);

            string fileName = fileNameResult.Value.ToString();

            string filePath = FileUpload(fileUpload, destinationPath, fileName);

            return Result<FileUploadResponse>.Success(new FileUploadResponse(filePath, fileName), "Success! Image file has been uploaded successfully.");
        }

        private bool HasValidFile(string extension)
        {
            return extension == DocumentFileType.JPG.ToString() ||
                extension == DocumentFileType.JPEG.ToString() ||
                extension == DocumentFileType.PNG.ToString() ||
                extension == DocumentFileType.BMP.ToString() ||
                extension == DocumentFileType.GIF.ToString();
        }
        private enum DocumentFileType
        {
            JPG,
            JPEG,
            PNG,
            BMP,
            GIF
        }
    }
}
