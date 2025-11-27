using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IssueTracker.BusinessLayer.Base;

namespace IssueTracker.BusinessLayer.Features.Projects.CreateProjectKey
{
    public class CreateProjectKeyRequest : BaseModel
    {
        public string Text { get; set; }
    }
    public class CreateProjectKeyResponse
    {
        public string Key { get; set; }
    }

    public class CreateProjectKeyController
    {
        public Result<CreateProjectKeyResponse> Handle(CreateProjectKeyRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Text) == true)
                return Result<CreateProjectKeyResponse>.Failure(
                    new Error(ErrorType.Validation, ErrorCode.BAD_REQUEST, "Text field should not be empty."));

            CreateProjectKeyResponse key = new CreateProjectKeyResponse { Key = Guid.NewGuid().ToString() };
            return Result<CreateProjectKeyResponse>.Success(key);
        }
    }
}
