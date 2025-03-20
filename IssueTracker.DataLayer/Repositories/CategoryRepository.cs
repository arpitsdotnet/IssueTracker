using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IssueTracker.ModelLayer.Base;
using IssueTracker.ModelLayer.SysCategories.Objects;
using IssueTracker.ModelLayer.SysCategories.Requests;

namespace IssueTracker.DataLayer.Repositories
{
    public interface ICategoryRepository
    {
        ResultList<Category> GetCategoties(GetCategoryRequest request);
    }
    public class CategoryRepository : ICategoryRepository
    {
        public readonly IApplicationDBContext _dBContext;

        public CategoryRepository()
        {
            _dBContext = SQLDataAccess.Instance;
        }

        public ResultList<Category> GetCategoties(GetCategoryRequest request)
        {
            var result = _dBContext.LoadData<GetCategoryRequest, Category>("sps_Categories", request);

            return result;
        }
    }
}
