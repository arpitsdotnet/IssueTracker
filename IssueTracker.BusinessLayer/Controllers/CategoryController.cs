using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IssueTracker.DataLayer.Repositories;

namespace IssueTracker.BusinessLayer.Controllers
{
    public class CategoryController : CommonController
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository = null)
        {
            _categoryRepository = categoryRepository ?? new CategoryRepository();
        }
    }
}
