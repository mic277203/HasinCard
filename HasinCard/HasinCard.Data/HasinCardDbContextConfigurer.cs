using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace HasinCard.Data
{
    public class HasinCardDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<HasinCardDbContext> builder, string connectionString)
        {
            builder.UseMySql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<HasinCardDbContext> builder, DbConnection connection)
        {
            builder.UseMySql(connection);
        }
    }
}
