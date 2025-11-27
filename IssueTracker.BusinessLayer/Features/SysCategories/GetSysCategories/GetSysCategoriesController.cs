using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using IssueTracker.BusinessLayer.Base;
using IssueTracker.BusinessLayer.Constants;
using IssueTracker.BusinessLayer.Extensions.ExceptionHandlers;
using IssueTracker.BusinessLayer.Features.UserIdentity.Models;
using IssueTracker.BusinessLayer.Services.Abstracts;
using IssueTracker.BusinessLayer.Services.LogService;

namespace IssueTracker.BusinessLayer.Features.SysCategories.GetSysCategories
{
    public class GetSysCategoriesRequest : BaseModel { }

    public class GetSysCategoriesResponse
    {
        public int CateId { get; set; }
        public string ClientUID { get; set; }
        public RowStatuses RowStatus { get; set; }
        public string CreatedOn { get; set; }
        public int CreatorId { get; set; }
        public User Creator { get; set; }
        public string ModifiedOn { get; set; }
        public int ModifierId { get; set; }
        public User Modifier { get; set; }
        public string CateKey { get; set; }
        public string CateTitle { get; set; }
        public string CateIconUrl { get; set; }
    }

    public sealed class GetSysCategoriesController
    {
        private readonly ILogger<GetSysCategoriesController> _logger;
        private readonly Validator _validations;
        private readonly GetSysCategoriesRepository _repository;
        public GetSysCategoriesController()
        {
            _logger = LoggerFactory<GetSysCategoriesController>.Instance;
            _validations = new Validator();
            _repository = new GetSysCategoriesRepository();
        }

        public class Validator : AbstractValidator<GetSysCategoriesRequest>
        {
            public Validator()
            {
                //RuleFor(x => x.ClientUID).NotNull().WithMessage("Client empty, please try re-login.");
                //RuleFor(x => x.ClientUID).NotEmpty().WithMessage("Client empty, please try re-login.");
                //RuleFor(x => x.ClientUID).Must(x => x.GetType() == typeof(Guid)).WithMessage("Client is invalid, please try re-login.");
            }
        }

        public async Task<ResultList<GetSysCategoriesResponse>> Handle(GetSysCategoriesRequest request)
        {
            _logger.Log("GetCategoriesController.GetCategoriesRequest", request);

            //ValidationResult validationResult = _validations.Validate(request);
            //if (validationResult.IsValid == false)
            //{
            //    return new ResultList<GetCategoriesResponse>(false) { Message = string.Join(",", validationResult.Errors) };
            //}

            var result = await _repository.Handle(request);

            return result;

            //return await DefaultExceptionHandler.Handle(_logger, async () =>
            //{
            //});
        }
    }
}
