using AutoMapper;
using HasinCard.Core.Domain;
using HasinCard.Data;
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
    public class SysUserServiceTest
    {
        private readonly ISysUserService _sysUserService;

        public SysUserServiceTest()
        {
            var services = new ServiceCollection();
            services.AddDbContext<HasinCardDbContext>(options => options.UseMySql("Server=39.108.3.178;user=root;password=root;Database=hasincard"));
            services.AddScoped<ISysUserService, SysUserService>();
            services.AddAutoMapper();

            var serviceProvider = services.BuildServiceProvider();

            _sysUserService = serviceProvider.GetService<ISysUserService>();
        }

        [Fact]
        public async Task CreateAsyncTestAsync()
        {
            var dto = new SysUsersRequestDto()
            {
                Email = "gogo@qq.com",
                Name = "petter",
                Password = "565148457",
                QQ = "565148457",
                TelNo = "18030180502"
            };

            var task = await _sysUserService.CreateAsync(dto);

            Assert.True(task);
        }
    }
}
