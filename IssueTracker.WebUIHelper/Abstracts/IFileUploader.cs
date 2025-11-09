using System.Web.UI.WebControls;
using IssueTracker.ModelLayer.Base;
using IssueTracker.WebUIHelper.Helpers.FileUploadHelpers;

namespace IssueTracker.WebUIHelper.Abstracts
{
    public interface IFileUploader
    {
        Result<FileUploadResponse> Upload(FileUpload fileUpload, string destinationPath, string fileSuffix);
    }
}
