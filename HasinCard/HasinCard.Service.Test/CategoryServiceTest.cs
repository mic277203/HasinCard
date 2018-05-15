using AutoMapper;
using HasinCard.Core.AuoMapper;
using HasinCard.Core.Domain;
using HasinCard.Data;
using HasinCard.Service.Category;
using HasinCard.Service.SysUser;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HasinCard.Service.Test
{
    public class CategoryServiceTest
    {
        private readonly ICategoryService _categoryService;

        public CategoryServiceTest()
        {
            _categoryService = ServiceTestBase.GetInstance().GetService<ICategoryService>();
        }

        [Fact]
        public void CategoryDtoTest()
        {
            var mapper = ServiceTestBase.GetInstance().GetService<IMapper>();

            Categorys c = new Categorys()
            {
                Id = 1,
                CategoryName="1",
                SysUserId=1
            };

            var dto = mapper.Map<CategorysReponseDto>(c);

            Assert.Equal(dto.Id, 1);
        }


        [Fact]
        public void CreateAsyncTestAsync()
        {
            _categoryService.CreateAsync(new CategorysRequestDto()
            {
                CategoryName = "name1",
                SortNo = 1,
                SysUserId = 1
            });

            _categoryService.CreateAsync(new CategorysRequestDto()
            {
                CategoryName = "name2",
                SortNo = 2,
                SysUserId = 2
            });

            _categoryService.CreateAsync(new CategorysRequestDto()
            {
                CategoryName = "name3",
                SortNo = 3,
                SysUserId = 3
            });

            _categoryService.CreateAsync(new CategorysRequestDto()
            {
                CategoryName = "name4",
                SortNo = 4,
                SysUserId = 4
            });

            _categoryService.CreateAsync(new CategorysRequestDto()
            {
                CategoryName = "name5",
                SortNo = 5,
                SysUserId = 5
            });

            _categoryService.CreateAsync(new CategorysRequestDto()
            {
                CategoryName = "name6",
                SortNo = 6,
                SysUserId = 6
            });

            _categoryService.CreateAsync(new CategorysRequestDto()
            {
                CategoryName = "name7",
                SortNo = 7,
                SysUserId = 7
            });
        }

        [Fact]
        public void DeleteAsyncTest()
        {
            _categoryService.DeleteAsync(1);
            _categoryService.DeleteAsync(10);
        }

        [Fact]
        public void EditAsyncTest()
        {

        }

        [Fact]
        public void QueryTest()
        {
            _categoryService.Query(1,"name", 0, 10);
        }
    }
}
