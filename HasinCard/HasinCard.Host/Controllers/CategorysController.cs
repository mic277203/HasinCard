using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HasinCard.Core;
using HasinCard.Service.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HasinCard.Host.Controllers
{
    [Produces("application/json")]
    [Route("api/Categorys")]
    [Authorize]
    public class CategorysController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategorysController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetPagedList(string categoryName, int start, int length)
        {
            var sub = User.Claims.FirstOrDefault(p => p.Type == "sub").Value.ToInt();
            var pageData = _categoryService.Query(sub,categoryName, start, length);

            return Json(pageData);
        }
    }
}