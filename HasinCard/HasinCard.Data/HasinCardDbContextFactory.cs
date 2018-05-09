using HasinCard.Core;
using HasinCard.Core.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Reflection;

namespace HasinCard.Data
{
    public class HasinCardDbContextFactory : IDesignTimeDbContextFactory<HasinCardDbContext>
    {
        public HasinCardDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<HasinCardDbContext>();
            var configuration = AppConfigurations.Get(Path.GetDirectoryName(typeof(HasinCardDbContextFactory).GetTypeInfo().Assembly.Location));

            HasinCardDbContextConfigurer.Configure(builder, configuration.GetConnectionString(HasinCardConsts.ConnectionStringName));

            return new HasinCardDbContext(builder.Options);
        }
    }
}
