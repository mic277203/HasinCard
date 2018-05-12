using HasinCard.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using HasinCard.Core.Linq;
using System.Threading.Tasks;
using HasinCard.Core.Domain;
using AutoMapper;

namespace HasinCard.Service.SysUser
{
    public class SysUserService : ISysUserService
    {
        private readonly HasinCardDbContext _context;
        // Create a field to store the mapper object
        private readonly IMapper _mapper;

        public SysUserService(HasinCardDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        public List<SysUsers> GetList()
        {
            return _context.SysUsers.ToList();
        }

        public SysUsersResponseDto GetById(int id)
        {
            var user = _context.SysUsers.FirstOrDefault(p => p.Id == id);
            var model = _mapper.Map<SysUsers, SysUsersResponseDto>(user);

            return model;
        }
    }
}
