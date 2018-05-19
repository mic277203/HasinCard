using AutoMapper;
using HasinCard.Core;
using HasinCard.Core.Domain;
using HasinCard.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using HasinCard.Core.Linq;
using System.Linq.Expressions;

namespace HasinCard.Service.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly HasinCardDbContext _context;
        // Create a field to store the mapper object
        private readonly IMapper _mapper;

        public CategoryService(HasinCardDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateAsync(CategorysRequestDto dto)
        {
            var model = _mapper.Map<Categorys>(dto);
            model.CreationTime = DateTime.Now;
            var task = await _context.Categorys.AddAsync(model);
            await _context.SaveChangesAsync();

            return model.Id != 0;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var model = _context.Categorys.FirstOrDefault(p => p.Id == id);

            if (model == null)
            {
                return false;
            }
            else
            {
                model.IsDelete = true;
                var result = await _context.SaveChangesAsync();

                return true;
            }
        }
        public async Task<bool> EditAsync(CategorysRequestDto dto)
        {
            var category = _context.Categorys.FirstOrDefault(p => p.Id == dto.Id);

            if (category == null)
            {
                return false;
            }

            _mapper.Map(dto, category);
            category.LastModificationTime = DateTime.Now;
            await _context.SaveChangesAsync();

            return true;
        }
        public HasinPagerModel<CategorysReponseDto> Query(int id, string categoryName, int start, int length)
        {
            var queryable = _context.Categorys.AsQueryable().Where(p => p.SysUserId == id && !p.IsDelete);
            var recordsTotal = queryable.Count();
            int recordsFiltered;
            List<Categorys> data;

            if (string.IsNullOrEmpty(categoryName))
            {
                recordsFiltered = recordsTotal;
                data = queryable.ToAscPager(null,
                               o => o.SortNo, start, length);
            }
            else
            {
                recordsFiltered = queryable.Where(w => w.CategoryName.Contains(categoryName)).Count();
                data = queryable.ToAscPager(w => w.CategoryName.Contains(categoryName),
                               o => o.SortNo, start, length);
            }

            var pager = new HasinPagerModel<CategorysReponseDto>()
            {
                Data = _mapper.Map<List<CategorysReponseDto>>(data),
                Draw = (start == 0) ? 1 : (start / length) + 1,
                RecordsTotal = recordsTotal,
                RecordsFiltered = recordsFiltered
            };

            return pager;
        }
    }
}
