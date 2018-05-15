using HasinCard.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using HasinCard.Core.Linq;
using System.Linq;
using Xunit.Abstractions;

namespace HasinCard.Core.Test
{
    public class LinqExtensionsTest
    {
        List<SysUsers> listSysUsers;
        private readonly ITestOutputHelper _output;
        public LinqExtensionsTest(ITestOutputHelper output)
        {
            _output = output;
            listSysUsers = new List<SysUsers>();

            for (int i = 1; i < 1000; i++)
            {
                listSysUsers.Add(new SysUsers()
                {
                    Id = i,
                    Name = "name" + i.ToString()
                });
            }
        }

        [Fact]
        public void ToPagerTest()
        {
            var page = listSysUsers.AsQueryable().ToDescPager(p => p.Name == "name1", p => p.Id, 0, 100);
            _output.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(page));

            var page2 = listSysUsers.AsQueryable().ToDescPager(p => p.Name.Contains("name"), p => p.Id, 0, 100);
            _output.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(page2));

            var page3 = listSysUsers.AsQueryable().ToDescPager(p => p.Name.Contains("1"), p => p.Name,1, 10);
            _output.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(page3));
        }
    }
}
