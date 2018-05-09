using HasinCard.Core.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace HasinCard.Core.Test
{
    public class AppConfigurationsTest
    {
        [Fact]
        public void Test()
        {
            var result = AppConfigurations.Get(Path.GetDirectoryName(typeof(AppConfigurationsTest).GetTypeInfo().Assembly.Location));
            Assert.NotNull(result.GetConnectionString("Default"));
        }
    }
}
