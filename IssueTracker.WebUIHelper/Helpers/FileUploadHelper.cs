using System;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;
using IssueTracker.BusinessLayer.Base;
using IssueTracker.BusinessLayer.Services.Abstracts;
using IssueTracker.BusinessLayer.Services.Helpers;
using IssueTracker.WebUIHelper.Constants;

namespace IssueTracker.WebUIHelper.Helpers
{
    public abstract class FileUploadHelper
    {
        private readonly IDateTimeProvider _dateTimeProvider;

        public FileUploadHelper(
            IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }
        public FileUploadHelper() : this(
            new DateTimeHelper())
        {
        }

        public Result<string> GenerateFileName(FileUpload fileUpload, string destinationPath, string imageSuffix, string allowedFileType, Func<string, bool> HasValidFile)
        {
            if (fileUpload.HasFile == false)
                return Result<string>.Failure(new Error(ErrorType.Validation, "404", "Oops! File must not be empty."));

            string extension = Path.GetExtension(fileUpload.PostedFile.FileName).Replace(".", "").ToUpper();

            if (string.IsNullOrWhiteSpace(extension) || HasValidFile(extension) == false)
                return Result<string>.Failure(new Error(ErrorType.Validation, "400", $"Oops! File type is invalid (allowed file types: {allowedFileType})"));

            string dateSuffix = _dateTimeProvider.DateTimeNow.ToString(DateTimeConst.ExportFormat);
            string imageName = $"::CompanyDataBLModel.ShortName::_{imageSuffix}_{dateSuffix}.{extension}";

            return Result<string>.Success(imageName, "Success.");
        }

        /// <summary>
        /// It upload the file into file system based on destination path.
        /// </summary>
        /// <param name="fileUpload"></param>
        /// <param name="destinationPath"></param>
        /// <param name="imageName"></param>
        /// <returns>Complete file path, starts from root directory.</returns>
        public string FileUpload(FileUpload fileUpload, string destinationPath, string imageName)
        {
            string imageFile = destinationPath + imageName;
            string imagePath = HttpContext.Current.Server.MapPath(imageFile);
            fileUpload.SaveAs(imagePath);

            return imagePath;
        }
    }
}