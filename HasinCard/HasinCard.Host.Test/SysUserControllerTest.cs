using HasinCard.Core.Domain;
using HasinCard.Host.Controllers;
using HasinCard.Service.SysUser;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace HasinCard.Host.Test
{
    public class SysUserControllerTest
    {
        private SysUserController _target;
        private Mock<ISysUserService> _mo;
        private readonly ITestOutputHelper output;
        private List<SysUsersRequestDto> listDtos;

        public SysUserControllerTest(ITestOutputHelper output)
        {
            this.output = output;
            _mo = new Mock<ISysUserService>();

            _mo.Setup(p => p.CreateAsync(It.IsAny<SysUsersRequestDto>())).Returns(Task.FromResult(true));
            output.WriteLine("初始化mock完成");
            _target = new SysUserController(_mo.Object);

            listDtos = new List<SysUsersRequestDto>
            {
                new SysUsersRequestDto()
            {
                Email = "gogo@qq.com",
                Name = "petter",
                Password = "565148457",
                QQ = "565148457",
                TelNo = "18030180502"
            },
              new SysUsersRequestDto()
            {
                Email = "gogoqq.com",
                Name = "petter",
                Password = "565148457",
                QQ = "565148457",
                TelNo = "18030180502"
            },
               new SysUsersRequestDto()
            {
                Email = "gogoqq.com",
                Name = "",
                Password = "565148457",
                QQ = "565148457",
                TelNo = "18030180502"
            },
                new SysUsersRequestDto()
            {
                Email = "gogo@qq.com",
                Name = "fsdfhjsdfhjsdfjskdfhjkshfjkhsfjkhsdjkfhsdjkfhjskdfhsdhfksdfkfhjskdjskdfffffffff",
                Password = "565148457",
                QQ = "565148457",
                TelNo = "18030180502"
            },
                new SysUsersRequestDto()
            {
                Email = "gogo@qq.com",
                Name = "petter",
                Password = "",
                QQ = "565148457",
                TelNo = "18030180502"
            },
                new SysUsersRequestDto()
            {
                Email = "gogo@qq.com",
                Name = "petter",
                Password = "565148457",
                QQ = "56514841231257",
                TelNo = "18030180502"
            },
              new SysUsersRequestDto()
            {
                Email = "gogo@qq.com",
                Name = "petter",
                Password = "565148457",
                QQ = "4841231257",
                TelNo = "18030180502"
            },
              new SysUsersRequestDto()
            {
                Email = "gogo@qq.com",
                Name = "petter",
                Password = "565148457",
                QQ = "4841231257",
                TelNo = "180301805022"
            }
        };
        }

        [Fact]
        public async Task CreateTest()
        {
            for (int i = 0; i < listDtos.Count; i++)
            {
                var result = await _target.Create(listDtos[i]);
                var message = Newtonsoft.Json.JsonConvert.SerializeObject(result);

                output.WriteLine(message);
            }
        }
    }
}
