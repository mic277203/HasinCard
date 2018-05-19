using AutoMapper;
using HasinCard.Core.AuoMapper;
using HasinCard.Data;
using HasinCard.Service.Category;
using HasinCard.Service.SysUser;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HasinCard.Service.Test
{
    public class ServiceTestBase
    {
        private static ServiceProvider _serviceProvider;
        private static object obj = new object();

        public static ServiceProvider GetInstance()
        {
            if (_serviceProvider == null)
            {
                lock (obj)
                {
                    if (_serviceProvider == null)
                    {
                        var serviceCollection = new ServiceCollection();
                        serviceCollection.AddDbContext<HasinCardDbContext>(options => options.UseMySql("Server=149.28.31.100;user=root;password=root;Database=hasincard"));
                        serviceCollection.AddSingleton<ICategoryService, CategoryService>();
                        serviceCollection.AddSingleton<ISysUserService, SysUserService>();


                        serviceCollection.AddAutoMapper(typeof(MappingProfile));
                        _serviceProvider = serviceCollection.BuildServiceProvider();
                    }
                }
            }

            return _serviceProvider;
        }
    }
}
