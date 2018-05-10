using HasinCard.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using HasinCard.Core.Linq;
using System.Threading.Tasks;
using HasinCard.Core.Domain;

namespace HasinCard.Service.SysUser
{
    public class SysUserService : ISysUserService
    {
        private readonly HasinCardDbContext _context;

        public SysUserService(HasinCardDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        public List<SysUsers> GetList()
        {
            return _context.SysUsers.ToList();
        }
    }
}
