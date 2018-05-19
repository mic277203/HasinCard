using HasinCard.Core.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Xunit.Abstractions;

namespace HasinCard.Core.Test
{
    public class AppConfigurationsTest
    {
        private readonly ITestOutputHelper _output;

        public AppConfigurationsTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Test()
        {
            var result = AppConfigurations.Get(Path.GetDirectoryName(typeof(AppConfigurationsTest).GetTypeInfo().Assembly.Location));
            Assert.NotNull(result.GetConnectionString("Default"));
        }
    }
}
