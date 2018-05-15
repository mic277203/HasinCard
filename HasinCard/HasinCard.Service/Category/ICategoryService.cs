using HasinCard.Core;
using HasinCard.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HasinCard.Service.Category
{
    public interface ICategoryService
    {
        Task<bool> CreateAsync(CategorysRequestDto dto);
        Task<bool> DeleteAsync(int Id);
        Task<bool> EditAsync(CategorysRequestDto dto);
        HasinPagerModel<CategorysReponseDto> Query(int userId, string categoryName, int start, int length);
    }
}
