using HasinCard.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HasinCard.Service.SysUser
{
    public interface ISysUserService
    {
        /// <summary>
        /// 获取所有的用户
        /// </summary>
        /// <returns></returns>
        List<SysUsers> GetList();

        /// <summary>
        /// 根据ID获取用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        SysUsersResponseDto GetById(int id);

        Task<bool> CreateAsync(SysUsersRequestDto dto);

        /// <summary>
        /// 已存在邮箱
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        bool ExistEmail(string email);

        bool ValidateCredentials(string username, string password);
        SysUsers FindBySubjectId(string subjectId);
        SysUsers FindByUsername(string username);
    }
}
