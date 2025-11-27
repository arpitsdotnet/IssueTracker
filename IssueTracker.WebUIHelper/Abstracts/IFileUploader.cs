using System.Web.UI.WebControls;
using IssueTracker.BusinessLayer.Base;
using IssueTracker.WebUIHelper.Helpers.FileUploadHelpers;

namespace IssueTracker.WebUIHelper.Abstracts
{
    public interface IFileUploader
    {
        Result<FileUploadResponse> Upload(FileUpload fileUpload, string destinationPath, string fileSuffix);
    }
}
