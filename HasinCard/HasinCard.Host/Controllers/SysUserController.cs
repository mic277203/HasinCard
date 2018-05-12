using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HasinCard.Core;
using HasinCard.Core.Domain;
using HasinCard.Core.Utility;
using HasinCard.Core.Validator.SysUser;
using HasinCard.Service.SysUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HasinCard.Host.Controllers
{
    [Produces("application/json")]
    [Route("api/SysUser")]
    [Authorize]
    public class SysUserController : Controller
    {
        private readonly ISysUserService _sysUserService;
        public SysUserController(ISysUserService sysUserService)
        {
            _sysUserService = sysUserService;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _sysUserService.GetById(id);

            if (result == null)
            {
                return Json(ApiJsonResult.ErrorResult("没有找到用户"));
            }
            else
            {
                return Json(ApiJsonResult.SuccessResult("成功", result));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(SysUsersRequestDto dto)
        {
            if (dto == null)
            {
                return Json(ApiJsonResult.ErrorResult("注册信息为空"));
            }

            var validResult = new SysUsersValidator().Validate(dto);

            if (!validResult.IsValid)
            {
                string errorMsg = string.Join('\n', validResult.Errors.AsQueryable().Select(p => p.ErrorMessage).ToArray());
                return Json(ApiJsonResult.ErrorResult(errorMsg));
            }

            var result = await _sysUserService.CreateAsync(dto);

            if (result)
            {
                return Json(ApiJsonResult.SuccessResult("成功"));
            }
            else
            {
                return Json(ApiJsonResult.ErrorResult("失败"));
            }
        }
    }
}